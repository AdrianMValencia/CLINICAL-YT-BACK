using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Commands.ChangeStateCommand
{
    public class ChangeStateMedicCommand : IRequest<BaseResponse<bool>>
    {
        public int MedicId {  get; set; }
        public int State {  get; set; }
    }
}