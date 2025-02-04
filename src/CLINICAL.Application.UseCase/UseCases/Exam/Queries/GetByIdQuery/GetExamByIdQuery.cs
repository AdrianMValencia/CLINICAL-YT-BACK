using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetByIdQuery
{
    public class GetExamByIdQuery : IRequest<BaseResponse<GetExamByIdResponseDto>>
    {
        public int ExamId { get; set; }
    }
}