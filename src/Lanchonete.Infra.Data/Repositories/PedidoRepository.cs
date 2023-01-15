using Lanchonete.Domain.Interfaces.Repositories;
using Lanchonete.Domain.Models;
using Lanchonete.Infra.Data.Context;
using Lanchonete.Infra.Data.Repositories.Shared;

namespace Lanchonete.Infra.Data.Repositories;

public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
{
    public PedidoRepository(DataContext context) : base(context)
    {
    }
}
