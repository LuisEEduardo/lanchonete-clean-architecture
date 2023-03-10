using Lanchonete.Domain.Models;
using Lanchonete.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Lanchonete.Infra.Data.Context;

public class DataContext : DbContext
{
    public DbSet<Lanche> Lanches { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<LanchePedido> LanchePedido { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LancheMap());
        modelBuilder.ApplyConfiguration(new PedidoMap());
        modelBuilder.ApplyConfiguration(new LanchePedidoMap());

        base.OnModelCreating(modelBuilder);
    }

}
