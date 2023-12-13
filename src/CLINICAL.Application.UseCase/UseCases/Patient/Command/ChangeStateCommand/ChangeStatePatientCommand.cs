using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Command.ChangeStateCommand
{
    public class ChangeStatePatientCommand : IRequest<BaseResponse<bool>>
    {
        public int PatientId {  get; set; }
        public int State {  get; set; }
    }
}