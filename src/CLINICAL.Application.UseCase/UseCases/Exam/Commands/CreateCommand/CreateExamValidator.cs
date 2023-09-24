using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreateExamValidator : AbstractValidator<CreateExamCommand>
    {
        public CreateExamValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío.");
        }
    }
}