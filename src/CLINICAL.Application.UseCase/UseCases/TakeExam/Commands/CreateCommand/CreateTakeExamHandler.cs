using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Domain.Entities;
using CLINICAL.Utilities.Constants;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand
{
    public class CreateTakeExamHandler : IRequestHandler<CreateTakeExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTakeExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateTakeExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var takeExam = _mapper.Map<Entity.TakeExam>(request);
                var takeExamReg = await _unitOfWork.TakeExam.RegisterTakeExam(takeExam);

                foreach (var detail in takeExamReg.TakeExamDetails)
                {
                    var newTakeExamDetail = new TakeExamDetail
                    {
                        TakeExamId = (int)takeExamReg.TakeExamId!,
                        ExamId = detail.ExamId,
                        AnalysisId = detail.AnalysisId
                    };

                    await _unitOfWork.TakeExam.RegisterTakeExamDetail(newTakeExamDetail);
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
