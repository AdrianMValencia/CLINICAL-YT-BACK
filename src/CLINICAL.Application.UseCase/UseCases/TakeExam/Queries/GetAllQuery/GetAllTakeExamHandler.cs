using CLINICAL.Application.Dtos.TakeExam.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery
{
    public class GetAllTakeExamHandler :
        IRequestHandler<GetAllTakeExamQuery, BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTakeExamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>> Handle(GetAllTakeExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>();

            try
            {
                var count = await _unitOfWork.TakeExam.CountAsync(TB.TakeExam);
                var takeExams = await _unitOfWork.TakeExam.GetAllTakeExams(SP.uspTakeExamList, request);

                if (takeExams is not null)
                {
                    response.IsSuccess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.Data = takeExams;
                    response.Message = GlobalMessages.MESSAGE_QUERY;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
