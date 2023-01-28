using Lanchonete.Application.Interface;
using Lanchonete.Application.ViewModels;
using Lanchonete.Domain.Interfaces;
using Lanchonete.Domain.Models;
using Lanchonete.Web.Api.Controllers.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.Web.Api.Controllers.V1;

[Route("api/[controller]")]
public class PedidoController : MainController
{
    private readonly IPedidoApplication _app;

    public PedidoController(IPedidoApplication app,
                            INotifier notifier) : base(notifier)
    {
        _app = app;
    }

    [HttpGet]
    public async Task<IList<PedidoViewModel>> ObterTodos()
        => await _app.ObterTodos();

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<IList<PedidoViewModel>>> ObterPorId(Guid id)
        => CustomReponse(await _app.ObterPorId(id));

    [HttpPost]
    public async Task<ActionResult<PedidoViewModel>> Criar(IList<Guid> lanchesIds)
    {
        if (!ModelState.IsValid)
            return CustomReponse(ModelState);

        await _app.Criar(lanchesIds);

        return CustomReponse(lanchesIds);
    }

    [HttpPatch("alterarStatusPedido")]
    public async Task<ActionResult> AlterarStatusPedido(Guid pedidoId, StatusPedido statusPedido)
    {
        await _app.AlterarStatusPedido(pedidoId, statusPedido);

        return NoContent();
    }

    [HttpPut("adicionarLanche")]
    public async Task<ActionResult> AdicionarLanche(IList<Guid> lanchesId, Guid pedidoId)
    {
        await _app.AdicionarLanche(lanchesId, pedidoId);

        return NoContent();
    }

    [HttpPut("removerLanche")]
    public async Task<ActionResult> RemoverLanche(IList<Guid> lanchesId, Guid pedidoId)
    {
        await _app.RemoverLanche(lanchesId, pedidoId);

        return NoContent();
    }

}
