using FluentValidation;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Domain.Validations
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("O Nome deve ser informado!")
                .MinimumLength(3)
                .WithMessage("O Nome deve ter pelo menos 3 ou mais Caracteres!");

            RuleFor(c => c.Document)
                .NotEmpty()
                .WithMessage("O Documento deve ser informado!")
                .MaximumLength(20)
                .WithMessage("O Documento deve ter no máximo 20 caracteres!");

            RuleFor(c => c.Phone)
                .NotEmpty()
                .WithMessage("O Número deve ser informado!")
                .Length(10, 20)
                .WithMessage("O Número deve ter pelo menos 10 caracteres e no máximo 20 caracteres!");
        }
    }
}
