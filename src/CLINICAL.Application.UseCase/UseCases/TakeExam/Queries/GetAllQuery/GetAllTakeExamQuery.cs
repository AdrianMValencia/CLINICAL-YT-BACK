using CLINICAL.Application.Dtos.TakeExam.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery
{
    public class GetAllTakeExamQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
