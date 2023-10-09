using AutoMapper;
using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class PatientMappingsProfile : Profile
    {
        public PatientMappingsProfile()
        {
            CreateMap<Patient, GetPatientByIdResponseDto>()
                .ReverseMap();
        }
    }
}