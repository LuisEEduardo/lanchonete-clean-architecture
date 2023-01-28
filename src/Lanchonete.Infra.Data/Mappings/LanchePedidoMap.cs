using Lanchonete.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lanchonete.Infra.Data.Mappings;

public class LanchePedidoMap : IEntityTypeConfiguration<LanchePedido>
{
    public void Configure(EntityTypeBuilder<LanchePedido> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.LancheId)
               .HasColumnType("uniqueidentifier");

        builder.Property(x => x.PedidoId)
               .HasColumnType("uniqueidentifier");
    }
}
