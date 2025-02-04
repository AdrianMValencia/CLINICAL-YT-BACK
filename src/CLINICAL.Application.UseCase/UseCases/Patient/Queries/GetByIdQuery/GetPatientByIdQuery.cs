using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery
{
    public class GetPatientByIdQuery : IRequest<BaseResponse<GetPatientByIdResponseDto>>
    {
        public int PatientId { get; set; }
    }
}