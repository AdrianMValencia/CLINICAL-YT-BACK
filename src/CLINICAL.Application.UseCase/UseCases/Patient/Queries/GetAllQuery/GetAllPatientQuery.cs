using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery
{
    public class GetAllPatientQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}