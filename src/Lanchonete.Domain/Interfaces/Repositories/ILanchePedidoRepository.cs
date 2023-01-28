using Lanchonete.Domain.Interfaces.Repositories.Shared;
using Lanchonete.Domain.Models;

namespace Lanchonete.Domain.Interfaces.Repositories;

public interface ILanchePedidoRepository : IBaseRepository<LanchePedido>
{
    Task<LanchePedido> ObterLanchePedido(Guid pedidoId, Guid lancheId);
    Task RemoverLanchesPedidos(IList<LanchePedido> lanchesPedidos);
}
