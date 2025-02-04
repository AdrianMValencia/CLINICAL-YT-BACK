using CLINICAL.Application.Dtos.Medic;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery
{
    public class GetMedicByIdQuery : IRequest<BaseResponse<GetMedicByIdResponseDto>>
    {
        public int MedicId { get; set; }
    }
}