using FluentValidation;

namespace SysPizzaria.Application.DTOs.Validations
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Nome deve ser informado!");

            RuleFor(c => c.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Documento deve ser informado!");

            RuleFor(c => c.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Número deve ser informado!");
        }
    }
}