namespace CLINICAL.Domain.Entities
{
    public class ResultDetail
    {
        public int ResultDetailId { get; set; }
        public int ResultId { get; set; }
        public string? ResultFile { get; set; }
        public int TakeExamDetailId { get; set; }
    }
}
