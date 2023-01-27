using Lanchonete.Domain;
using Lanchonete.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lanchonete.Web.Api.Controllers.Shared;

[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotifier _notifier;

    public MainController(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected bool OperacaoValida()
        => !_notifier.HasNotification();

    protected ActionResult CustomReponse(object result = null)
    {
        if (OperacaoValida())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        return BadRequest(new
        {
            success = false,
            erros = _notifier.GetNotifications().Select(not => not.Message)
        });
    }

    protected ActionResult CustomReponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
            NotificarErroModelInvalida(modelState);

        return CustomReponse();
    }

    protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);

        foreach (var erro in erros)
        {
            var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            NotificarErro(erroMsg);
        }

    }

    protected void NotificarErro(string mensagem)
    {
        _notifier.Handle(new Nofication(mensagem));
    }

}
