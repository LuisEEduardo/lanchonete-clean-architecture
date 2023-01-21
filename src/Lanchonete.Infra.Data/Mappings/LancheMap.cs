using Lanchonete.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lanchonete.Infra.Data.Mappings;

public class LancheMap : IEntityTypeConfiguration<Lanche>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Lanche> builder)
    {
        builder.ToTable("Lanches");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
                        .IsRequired()
                        .HasColumnType("varchar(30)");

        builder.Property(x => x.Descricao)
                        .HasColumnType("varchar(200)");

        builder.Property(x => x.Preco)
                        .IsRequired()
                        .HasColumnType("DECIMAL");

        builder.Property(x => x.Status)
                        .IsRequired()
                        .HasColumnType("BIT");
    }
}
