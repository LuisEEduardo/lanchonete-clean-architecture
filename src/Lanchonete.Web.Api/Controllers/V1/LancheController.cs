using Lanchonete.Application.Interface;
using Lanchonete.Application.ViewModels;
using Lanchonete.Domain.Interfaces;
using Lanchonete.Web.Api.Controllers.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.Web.Api.Controllers.V1;

[Route("api/[controller]")]
public class LancheController : MainController
{
    private readonly ILancheApplication _app;

    public LancheController(ILancheApplication app,
                            INotifier notifier) : base(notifier)
    {
        _app = app;
    }

    [HttpGet]
    public async Task<IList<LancheViewModel>> ObterTodos()
        => await _app.ObterTodos();

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LancheViewModel>> ObterPorId(Guid id)
    {
        var result = await _app.ObterPorId(id);

        if (result is null)
            return NotFound();

        return result;
    }

    [HttpPost]
    public async Task<ActionResult<LancheViewModel>> Criar(LancheViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return CustomReponse(ModelState);

        await _app.Criar(viewModel);

        return CustomReponse(viewModel);
    }

    [HttpPut]
    public async Task<ActionResult<LancheViewModel>> Atualizar(LancheViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return CustomReponse(ModelState);

        await _app.Atualizar(viewModel);

        return CustomReponse(viewModel);
    }

    [HttpDelete]
    public async Task<ActionResult> Remover(Guid id)
    {
        if (!ModelState.IsValid)
            return CustomReponse(ModelState);

        await _app.Remover(id);

        return Ok();
    }

}
