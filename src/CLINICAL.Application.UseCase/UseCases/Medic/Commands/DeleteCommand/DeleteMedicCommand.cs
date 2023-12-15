using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Commands.DeleteCommand
{
    public class DeleteMedicCommand : IRequest<BaseResponse<bool>>
    {
        public int MedicId { get; set; }
    }
}