using FluentValidation;
using Lanchonete.Domain.Models;

namespace Lanchonete.Domain.Validations;

public class LancheValidation : AbstractValidator<Lanche>
{
    public LancheValidation()
    {
        RuleFor(x => x.Nome)
            .Length(2, 30)
            .WithMessage("A {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

        When(x => x.Descricao is not null, () =>
        {
            RuleFor(x => x.Descricao)
                .Length(2, 200)
                .WithMessage("A {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");
        });

        RuleFor(x => x.Preco)
            .GreaterThan(0)
            .WithMessage("A {PropertyName} deve ser maior que {ComparisonValue}");
    }
}
