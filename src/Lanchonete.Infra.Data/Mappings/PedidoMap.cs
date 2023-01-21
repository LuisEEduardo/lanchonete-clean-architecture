using Lanchonete.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lanchonete.Infra.Data.Mappings;

public class PedidoMap : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataHora)
                    .IsRequired()
                    .HasColumnType("DATETIME");

        builder.Property(x => x.StatusPedido)
                    .IsRequired()
                    .HasColumnType("INT");

        builder
            .HasMany(x => x.Lanches)
            .WithMany(x => x.Pedidos)
            .UsingEntity(x => x.ToTable("LanchePedido"));
    }
}
