using Lanchonete.Application.ViewModels;

namespace Lanchonete.Application.Interface;

public interface ILancheApplication
{
    Task<LancheViewModel> ObterPorId(Guid id);
    Task<IList<LancheViewModel>> ObterTodos(Guid id);
    Task Criar(LancheViewModel viewModel);
    Task Atualizar(LancheViewModel viewModel);
    Task Remover(Guid id);
}
