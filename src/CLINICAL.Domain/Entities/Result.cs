namespace CLINICAL.Domain.Entities
{
    public class Result
    {
        public int ResultId { get; set; }
        public int TakeExamId { get; set; }
        public int State { get ; set; }
        public DateTime AuditCreateDate { get; set; }
        public IEnumerable<ResultDetail>? ResultDetails { get; set; }
    }
}
