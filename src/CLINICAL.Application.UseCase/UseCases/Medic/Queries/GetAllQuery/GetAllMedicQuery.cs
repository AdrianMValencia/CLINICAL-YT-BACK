using CLINICAL.Application.Dtos.Medic;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetAllQuery
{
    public class GetAllMedicQuery : IRequest<BaseResponse<IEnumerable<GetAllMedicResponseDto>>>
    {
    }
}