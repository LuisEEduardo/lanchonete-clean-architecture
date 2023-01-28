using Lanchonete.Domain.Interfaces.Repositories;
using Lanchonete.Domain.Models;
using Lanchonete.Infra.Data.Context;
using Lanchonete.Infra.Data.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Lanchonete.Infra.Data.Repositories;

public class LanchePedidoRepository : BaseRepository<LanchePedido>, ILanchePedidoRepository
{
    public LanchePedidoRepository(DataContext context) : base(context)
    {
    }

    public async Task<LanchePedido> ObterLanchePedido(Guid pedidoId, Guid lancheId)
        => await _dbSet.FirstOrDefaultAsync(x => x.PedidoId == pedidoId && x.LancheId == lancheId);

    public async Task RemoverLanchesPedidos(IList<LanchePedido> lanchesPedidos)
    {
        _dbSet.RemoveRange(lanchesPedidos);
        await SaveChanges();
    }
}
