namespace CLINICAL.Domain.Entities
{
    public class TakeExamDetail
    {
        public int? TakeExamDetailId { get; set; }
        public int? TakeExamId { get; set; }
        public int? ExamId { get; set; }
        public int? AnalysisId {  get; set; }
    }
}
