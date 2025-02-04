using AutoMapper;
using CLINICAL.Application.Dtos.Result.Response;
using CLINICAL.Application.UseCase.UseCases.Result.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Result.Commands.UpdateCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class ResultMappingsProfile : Profile
    {
        public ResultMappingsProfile()
        {
            CreateMap<Result, GetResultByIdResponseDto>()
                .ReverseMap();

            CreateMap<ResultDetail, GetResultDetailByResultIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateResultCommand, Result>();
            CreateMap<UpdateResultCommand, Result>();
            CreateMap<UpdateResultDetailCommand, ResultDetail>();
        }
    }
}
