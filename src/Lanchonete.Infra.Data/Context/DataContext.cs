using Lanchonete.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lanchonete.Infra.Data.Context;

public class DataContext : DbContext
{
    public DbSet<Lanche> Lanches { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        base.OnModelCreating(modelBuilder);
    }

}
