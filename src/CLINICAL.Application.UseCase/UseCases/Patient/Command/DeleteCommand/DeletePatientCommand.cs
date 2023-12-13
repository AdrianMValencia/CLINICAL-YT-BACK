using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Command.DeleteCommand
{
    public class DeletePatientCommand : IRequest<BaseResponse<bool>>
    {
        public int PatientId { get; set; }
    }
}