using CLINICAL.Application.Dtos.Result.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Result.Queries.GetAllQuery
{
    public class GetAllResultQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllResultResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
