using Lanchonete.Domain.Interfaces.Repositories;
using Lanchonete.Domain.Models;
using Lanchonete.Infra.Data.Context;
using Lanchonete.Infra.Data.Repositories.Shared;

namespace Lanchonete.Infra.Data.Repositories;

public class LancheRepository : BaseRepository<Lanche>, ILancheRepository
{
    public LancheRepository(DataContext context) : base(context)
    {
    }
}
