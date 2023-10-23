using FluentValidation.Results;

namespace SysPizzaria.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }

        public virtual bool Validate(out ValidationResult validationResult)
        {
            validationResult = new ValidationResult();
            return validationResult.IsValid;
        }
    }
}
