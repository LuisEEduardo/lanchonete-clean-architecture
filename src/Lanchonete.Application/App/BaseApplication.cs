using FluentValidation;
using FluentValidation.Results;
using Lanchonete.Domain;
using Lanchonete.Domain.Interfaces;
using Lanchonete.Domain.Models;

namespace Lanchonete.Application.App;

public abstract class BaseApplication
{
    private readonly INotifier _notifier;

    protected BaseApplication(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected void Notificar(ValidationResult validationResult)
    {
        foreach (var erro in validationResult.Errors)
        {
            Notificar(erro.ErrorMessage);
        }
    }


    protected void Notificar(string mensagem)
    {
        _notifier.Handle(new Nofication(mensagem));
    }

    protected bool ExecutarValidacao<TValidation, TEntity>(TValidation validation, TEntity entity)
                                                        where TValidation : AbstractValidator<TEntity>
                                                        where TEntity : Entity
    {
        var validator = validation.Validate(entity);

        if (validator.IsValid)
            return true;

        Notificar(validator);

        return false;
    }

}
