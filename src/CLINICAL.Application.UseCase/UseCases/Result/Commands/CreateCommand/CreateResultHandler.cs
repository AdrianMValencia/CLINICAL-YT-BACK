using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.Interface.Services;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Domain.Entities;
using CLINICAL.Utilities.Constants;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Result.Commands.CreateCommand
{
    public class CreateResultHandler : IRequestHandler<CreateResultCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileStorage _fileStorage;

        public CreateResultHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileStorage fileStorage)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileStorage = fileStorage;
        }

        public async Task<BaseResponse<bool>> Handle(CreateResultCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var result = _mapper.Map<Entity.Result>(request);
                var resultReg = await _unitOfWork.Result.RegisterResult(result);

                foreach (var resultFile in request.ResultDetails)
                {
                    var newResultDetail = new ResultDetail
                    {
                        ResultId = resultReg.ResultId,
                        ResultFile = await _fileStorage
                        .SaveFile(FileServerContainers.RESULT_FILES, resultFile.ResultFile!),
                        TakeExamDetailId = resultFile.TakeExamDetailId
                    };

                    await _unitOfWork.Result.RegisterResultDetail(newResultDetail);
                }

                transaction.Complete();
                response.IsSuccess = true;
                response.Message = GlobalMessages.MESSAGE_SAVE;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
