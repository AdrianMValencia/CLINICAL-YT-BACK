using AutoMapper;
using CLINICAL.Application.Dtos.TakeExam.Response;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class TakeExamMappingProfile : Profile
    {
        public TakeExamMappingProfile()
        {
            CreateMap<GetTakeExamByIdResponseDto, TakeExam>()
                .ReverseMap();

            CreateMap<GetTakeExamDetailByTakeExamIdResponseDto, TakeExamDetail>()
                .ReverseMap();

            CreateMap<CreateTakeExamCommand, TakeExam>();
            CreateMap<CreateTakeExamDetailCommand, TakeExamDetail>();

            CreateMap<UpdateTakeExamCommand, TakeExam>();
            CreateMap<UpdateTakeExamDetailCommand, TakeExamDetail>();

            CreateMap<ChangeStateTakeExamCommand, TakeExam>();
        }
    }
}
