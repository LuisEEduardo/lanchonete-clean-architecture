using Lanchonete.Application.ViewModels;
using Lanchonete.Domain.Models;

namespace Lanchonete.Application.Interface;

public interface IPedidoApplication
{
    Task<PedidoViewModel> ObterPorId(Guid id);
    Task<IList<PedidoViewModel>> ObterTodos();
    Task Criar(IList<Guid> lanchesIds);
    Task AlterarStatusPedido(Guid pedidoId, StatusPedido statusPedido);
    Task AdicionarLanche(IList<Guid> lanchesId, Guid pedidoId);
    Task RemoverLanche(IList<Guid> lanchesId, Guid pedidoId);
}
