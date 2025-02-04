using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Command.CreateCommand
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.Names)
                .NotNull().WithMessage("El campo Nombres no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombres no puede ser vacío.");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("El campo Apellido Paterno no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Apellido Paterno no puede ser vacío.");

            RuleFor(x => x.MotherMaidenName)
                .NotNull().WithMessage("El campo Apellido Materno no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Apellido Materno no puede ser vacío.");

            RuleFor(x => x.DocumentNumber)
                .NotNull().WithMessage("El campo N° Documento no puede ser nulo.")
                .NotEmpty().WithMessage("El campo N° Documento no puede ser vacío.")
                .Must(BeNumeric!).WithMessage("El campo N° Documento debe contener sólo números.");

            RuleFor(x => x.Phone)
                .NotNull().WithMessage("El campo Teléfono no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Teléfono no puede ser vacío.")
                .Must(BeNumeric!).WithMessage("El campo Teléfono debe contener sólo números.");
        }

        private bool BeNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
    }
}