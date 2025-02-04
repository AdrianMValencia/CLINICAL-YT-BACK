namespace CLINICAL.Application.Dtos.Result.Response
{
    public class GetAllResultResponseDto
    {
        public int ResultId { get; set; }
        public string? Patient { get; set; }
        public string? PatientDocument { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public string? StateResult { get; set; }
    }
}
