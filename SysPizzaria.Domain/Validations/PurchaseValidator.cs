using FluentValidation;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Domain.Validations
{
    public class PurchaseValidator : AbstractValidator<Purchase>
    {
        public PurchaseValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("O IdProduto deve ser informado!")
                .GreaterThan(0)
                .WithMessage("O IdProduto deve ser maior que zero!");

            RuleFor(x => x.PersonId)
                .NotEmpty()
                .WithMessage("O IdPessoa deve ser informado!")
                .GreaterThan(0)
                .WithMessage("O IdPessoa deve ser maior que zero!");

            RuleFor(x => x.Date)
                .Equal(DateTime.Now);
        }
    }
}
