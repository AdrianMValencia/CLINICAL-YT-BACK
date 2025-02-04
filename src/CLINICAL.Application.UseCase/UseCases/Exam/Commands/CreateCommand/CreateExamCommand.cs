using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreateExamCommand : IRequest<BaseResponse<bool>>
    {
        public string? Name { get; set; }
        public int AnalysisId { get; set; }
    }
}