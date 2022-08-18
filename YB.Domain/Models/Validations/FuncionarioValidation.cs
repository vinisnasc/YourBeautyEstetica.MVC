using FluentValidation;

namespace YB.Domain.Models.Validations
{
    public class FuncionarioValidation : AbstractValidator<Funcionario>
    {
        public FuncionarioValidation()
        {
            RuleFor(n => n.Nome).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
