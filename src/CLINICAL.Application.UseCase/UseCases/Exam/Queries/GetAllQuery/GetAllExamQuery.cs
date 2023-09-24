using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetAllQuery
{
    public class GetAllExamQuery : IRequest<BaseResponse<IEnumerable<GetAllExamResponseDto>>>
    {
    }
}