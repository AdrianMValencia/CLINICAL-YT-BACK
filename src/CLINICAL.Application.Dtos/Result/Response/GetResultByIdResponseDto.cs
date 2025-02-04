namespace CLINICAL.Application.Dtos.Result.Response
{
    public class GetResultByIdResponseDto
    {
        public int ResultId { get; set; }
        public int TakeExamId { get; set; }
        public IEnumerable<GetResultDetailByResultIdResponseDto>? ResultDetails { get; set; }
    }

    public class GetResultDetailByResultIdResponseDto
    {
        public int ResultDetailId { get; set; }
        public int ResultId { get; set; }
        public string? ResultFile { get; set; }
        public int TakeExamDetailId { get; set; }
    }
}
