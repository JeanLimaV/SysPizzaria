using FluentValidation;
using SysPizzaria.Domain.Entities;

namespace SysPizzaria.Domain.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("O Nome do Produto deve ser informado!")
                .MinimumLength(2)
                .WithMessage("O Nome do Produto deve ter no mínimo 2 caracteres!");

            RuleFor(p => p.CodERP)
                .NotEmpty()
                .WithMessage("O código ERP deve ser informado!")
                .MaximumLength(10)
                .WithMessage("O código ERP deve ter no máximo 10 caracteres!");

            RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("O Preço deve ser informado!")
                .GreaterThan(0)
                .WithMessage("O Preço deve ser maior que zero!");
        }
    }
}
