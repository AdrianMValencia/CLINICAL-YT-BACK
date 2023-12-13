using AutoMapper;
using CLINICAL.Application.Dtos.Medic;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class MedicMappingsProfile : Profile
    {
        public MedicMappingsProfile()
        {
            CreateMap<Medic, GetMedicByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateMedicCommand, Medic>();
        }
    }
}