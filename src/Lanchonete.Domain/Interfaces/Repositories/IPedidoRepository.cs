using Lanchonete.Domain.Interfaces.Repositories.Shared;
using Lanchonete.Domain.Models;

namespace Lanchonete.Domain.Interfaces.Repositories;

public interface IPedidoRepository : IBaseRepository<Pedido>
{
    Task<Pedido> ObterPedidoCompleto(Guid pedidoId);
}
