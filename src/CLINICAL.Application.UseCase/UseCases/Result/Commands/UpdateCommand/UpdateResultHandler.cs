using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.Interface.Services;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Domain.Entities;
using CLINICAL.Utilities.Constants;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Result.Commands.UpdateCommand
{
    public class UpdateResultHandler : IRequestHandler<UpdateResultCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileStorage _fileStorage;

        public UpdateResultHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileStorage fileStorage)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileStorage = fileStorage;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateResultCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var result = _mapper.Map<Entity.Result>(request);
                await _unitOfWork.Result.EditResult(result);

                foreach (var resultDetail in request.ResultDetails)
                {
                    var pathImage = await _unitOfWork.Result
                        .GetResultFile(request.ResultId, resultDetail.ResultDetailId);

                    var editResultDetail = new ResultDetail
                    {
                        ResultDetailId = resultDetail.ResultDetailId,
                        ResultFile = await _fileStorage
                        .EditFile(FileServerContainers.RESULT_FILES, resultDetail.ResultFile!, pathImage.ResultFile!),
                        TakeExamDetailId = resultDetail.TakeExamDetailId,
                    };

                    await _unitOfWork.Result.EditResultDetail(editResultDetail);
                }

                transaction.Complete();
                response.IsSuccess = true;
                response.Message = GlobalMessages.MESSAGE_UPDATE;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
