using AutoMapper;
using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Exam.Commands.UpdateCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, GetExamByIdResponseDto>()
                .ReverseMap();

            CreateMap<CreateExamCommand, Exam>();

            CreateMap<UpdateExamCommand, Exam>();

            CreateMap<ChangeStateExamCommand, Exam>();
        }
    }
}