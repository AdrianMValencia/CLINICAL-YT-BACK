using AutoMapper;
using CLINICAL.Application.Dtos.TakeExam.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetByIdQuery
{
    public class GetTakeExamByIdHandler : IRequestHandler<GetTakeExamByIdQuery, BaseResponse<GetTakeExamByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTakeExamByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetTakeExamByIdResponseDto>> Handle(GetTakeExamByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetTakeExamByIdResponseDto>();

            try
            {
                var takeExams = await _unitOfWork.TakeExam.GetTakeExamById(request.TakeExamId);
                takeExams.TakeExamDetails = await _unitOfWork.TakeExam
                    .GetTakeExamDetailByTakeExamId(request.TakeExamId);

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetTakeExamByIdResponseDto>(takeExams);
                response.Message = GlobalMessages.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
