using CLINICAL.Application.Dtos.Result.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Result.Queries.GetByIdQuery
{
    public class GetResultByIdQuery : IRequest<BaseResponse<GetResultByIdResponseDto>>
    {
        public int ResultId { get; set; }
    }
}
