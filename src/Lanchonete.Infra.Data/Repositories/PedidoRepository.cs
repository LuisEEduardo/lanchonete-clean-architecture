using Lanchonete.Domain.Interfaces.Repositories;
using Lanchonete.Domain.Models;
using Lanchonete.Infra.Data.Context;
using Lanchonete.Infra.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Lanchonete.Infra.Data.Repositories;

public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
{
    public PedidoRepository(DataContext context) : base(context)
    {
    }

    public async Task<Pedido> ObterPedidoCompleto(Guid pedidoId)
        => await _dbSet
                        .Include(x => x.Lanches)
                            .ThenInclude(x => x.Lanche)
                        .FirstOrDefaultAsync(x => x.Id == pedidoId);
}
