using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery
{
    public class GetAllPatientQuery : IRequest<BaseResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
    }
}