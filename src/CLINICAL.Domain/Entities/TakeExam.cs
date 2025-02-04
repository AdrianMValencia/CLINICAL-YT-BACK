namespace CLINICAL.Domain.Entities
{
    public class TakeExam
    {
        public int? TakeExamId { get; set; }
        public int? PatientId {  get; set; }
        public int? MedicId {  get; set; }
        public int? State { get; set; }
        public DateTime? AuditCreateDate { get; set; }
        public IEnumerable<TakeExamDetail> TakeExamDetails { get; set; } = null!;
    }
}
