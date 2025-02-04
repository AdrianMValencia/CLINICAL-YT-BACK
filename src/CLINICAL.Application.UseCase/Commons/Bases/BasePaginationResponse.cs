namespace CLINICAL.Application.UseCase.Commons.Bases
{
    public class BasePaginationResponse<T> : BaseGenericResponse<T>
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount {  get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
