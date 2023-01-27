﻿// <auto-generated />
using System;
using Lanchonete.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lanchonete.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LanchePedido", b =>
                {
                    b.Property<Guid>("LanchesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PedidosId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LanchesId", "PedidosId");

                    b.HasIndex("PedidosId");

                    b.ToTable("LanchePedido", (string)null);
                });

            modelBuilder.Entity("Lanchonete.Domain.Models.Lanche", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("DECIMAL");

                    b.Property<bool>("Status")
                        .HasColumnType("BIT");

                    b.HasKey("Id");

                    b.ToTable("Lanches", (string)null);
                });

            modelBuilder.Entity("Lanchonete.Domain.Models.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("DATETIME");

                    b.Property<int>("StatusPedido")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("LanchePedido", b =>
                {
                    b.HasOne("Lanchonete.Domain.Models.Lanche", null)
                        .WithMany()
                        .HasForeignKey("LanchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lanchonete.Domain.Models.Pedido", null)
                        .WithMany()
                        .HasForeignKey("PedidosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
