using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand
{
    public class UpdateTakeExamCommand : IRequest<BaseResponse<bool>>
    {
        public int TakeExamId {  get; set; }
        public int PatientId { get; set; }
        public int MedicId {  get; set; }
        public IEnumerable<UpdateTakeExamDetailCommand> TakeExamDetails { get; set; } = null!;
    }

    public class UpdateTakeExamDetailCommand
    {
        public int TakeExamDetailId { get; set; }
        public int ExamId { get; set; }
        public int AnalysisId { get; set; }
    }
}
