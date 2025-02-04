namespace CLINICAL.Application.Dtos.Exam.Response
{
    public class GetAllExamResponseDto
    {
        public int ExamId { get; set; }
        public string? Name { get; set; }
        public string? Analysis { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string? StateExam { get; set; }
    }
}