using FluentValidation;

namespace YB.Domain.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(n => n.Nome).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
