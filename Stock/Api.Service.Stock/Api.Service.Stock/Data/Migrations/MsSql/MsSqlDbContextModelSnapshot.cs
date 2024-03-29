﻿// <auto-generated />
using System;
using Api.Service.Stock.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.Service.Stock.Data.Migrations.MsSql
{
    [DbContext(typeof(MsSqlDbContext))]
    partial class MsSqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Api.Service.Stock.Models.Cliente", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Cel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnderecoNumero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PeriodEnd")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodEnd");

                    b.Property<DateTime>("PeriodStart")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("PeriodStart");

                    b.Property<string>("Rg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Uid");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("Clientes");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb
                                .HasPeriodStart("PeriodStart")
                                .HasColumnName("PeriodStart");
                            ttb
                                .HasPeriodEnd("PeriodEnd")
                                .HasColumnName("PeriodEnd");
                        }
                    ));
                });

            modelBuilder.Entity("Api.Service.Stock.Models.Compra", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FornecedorUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("NumeroNotaFiscal")
                        .HasColumnType("int");

                    b.Property<Guid?>("TipoPagamentoUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Uid");

                    b.HasIndex("FornecedorUid");

                    b.HasIndex("TipoPagamentoUid");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.Fornecedor", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnderecoNumero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Uid");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.ItensCompra", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("CompraUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProdutoUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Quantidade")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Uid");

                    b.HasIndex("CompraUid");

                    b.HasIndex("ProdutoUid");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("ItensCompras");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.ItensVenda", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProdutoUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Quantidade")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("VendaUid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Uid");

                    b.HasIndex("ProdutoUid");

                    b.HasIndex("VendaUid");

                    b.ToTable("ItensVendas");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.Produto", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorPago")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorVenda")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Uid");

                    b.HasIndex("Estoque");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.TipoPagamento", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RolesCanRead")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Uid");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("TipoPagamentos");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.Venda", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("ClienteUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desconto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroNotaFiscal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TipoPagamentoUid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Total")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Uid");

                    b.HasIndex("ClienteUid");

                    b.HasIndex("TipoPagamentoUid");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.Compra", b =>
                {
                    b.HasOne("Api.Service.Stock.Models.Fornecedor", "DbFornecedorModel")
                        .WithMany("DbComprasModel")
                        .HasForeignKey("FornecedorUid");

                    b.HasOne("Api.Service.Stock.Models.TipoPagamento", "DbTipoPagamentoModel")
                        .WithMany("DbComprasModel")
                        .HasForeignKey("TipoPagamentoUid");

                    b.Navigation("DbFornecedorModel");

                    b.Navigation("DbTipoPagamentoModel");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.ItensCompra", b =>
                {
                    b.HasOne("Api.Service.Stock.Models.Compra", "DbCompra")
                        .WithMany("DbItensCompraModel")
                        .HasForeignKey("CompraUid")
                        .IsRequired();

                    b.HasOne("Api.Service.Stock.Models.Produto", "DbProduto")
                        .WithMany("DbItensCompraModel")
                        .HasForeignKey("ProdutoUid")
                        .IsRequired();

                    b.Navigation("DbCompra");

                    b.Navigation("DbProduto");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.ItensVenda", b =>
                {
                    b.HasOne("Api.Service.Stock.Models.Produto", "DbProduto")
                        .WithMany("DbItensVendasModel")
                        .HasForeignKey("ProdutoUid")
                        .IsRequired();

                    b.HasOne("Api.Service.Stock.Models.Venda", "DbVenda")
                        .WithMany("DbItensVendasModel")
                        .HasForeignKey("VendaUid")
                        .IsRequired();

                    b.Navigation("DbProduto");

                    b.Navigation("DbVenda");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.Venda", b =>
                {
                    b.HasOne("Api.Service.Stock.Models.Cliente", "DbCliente")
                        .WithMany("DbVendasModel")
                        .HasForeignKey("ClienteUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Service.Stock.Models.TipoPagamento", "DbTipoPagamento")
                        .WithMany("DbVendasModel")
                        .HasForeignKey("TipoPagamentoUid");

                    b.Navigation("DbCliente");

                    b.Navigation("DbTipoPagamento");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.Cliente", b =>
                {
                    b.Navigation("DbVendasModel");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.Compra", b =>
                {
                    b.Navigation("DbItensCompraModel");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.Fornecedor", b =>
                {
                    b.Navigation("DbComprasModel");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.Produto", b =>
                {
                    b.Navigation("DbItensCompraModel");

                    b.Navigation("DbItensVendasModel");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.TipoPagamento", b =>
                {
                    b.Navigation("DbComprasModel");

                    b.Navigation("DbVendasModel");
                });

            modelBuilder.Entity("Api.Service.Stock.Models.Venda", b =>
                {
                    b.Navigation("DbItensVendasModel");
                });
#pragma warning restore 612, 618
        }
    }
}
