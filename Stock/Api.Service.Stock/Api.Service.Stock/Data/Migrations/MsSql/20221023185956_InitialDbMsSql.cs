using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Service.Stock.Data.Migrations.MsSql
{
    public partial class InitialDbMsSql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Uid);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ClientesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoNumero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagem = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "TipoPagamentos",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPagamentos", x => x.Uid);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeroNotaFiscal = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FornecedorUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TipoPagamentoUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Compras_Fornecedores_FornecedorUid",
                        column: x => x.FornecedorUid,
                        principalTable: "Fornecedores",
                        principalColumn: "Uid");
                    table.ForeignKey(
                        name: "FK_Compras_TipoPagamentos_TipoPagamentoUid",
                        column: x => x.TipoPagamentoUid,
                        principalTable: "TipoPagamentos",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroNotaFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desconto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoPagamentoUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteUid",
                        column: x => x.ClienteUid,
                        principalTable: "Clientes",
                        principalColumn: "Uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_TipoPagamentos_TipoPagamentoUid",
                        column: x => x.TipoPagamentoUid,
                        principalTable: "TipoPagamentos",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "ItensCompras",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Quantidade = table.Column<double>(type: "float", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CompraUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCompras", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_ItensCompras_Compras_CompraUid",
                        column: x => x.CompraUid,
                        principalTable: "Compras",
                        principalColumn: "Uid");
                    table.ForeignKey(
                        name: "FK_ItensCompras_Produtos_ProdutoUid",
                        column: x => x.ProdutoUid,
                        principalTable: "Produtos",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateTable(
                name: "ItensVendas",
                columns: table => new
                {
                    Uid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Quantidade = table.Column<double>(type: "float", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VendaUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensVendas", x => x.Uid);
                    table.ForeignKey(
                        name: "FK_ItensVendas_Produtos_ProdutoUid",
                        column: x => x.ProdutoUid,
                        principalTable: "Produtos",
                        principalColumn: "Uid");
                    table.ForeignKey(
                        name: "FK_ItensVendas_Vendas_VendaUid",
                        column: x => x.VendaUid,
                        principalTable: "Vendas",
                        principalColumn: "Uid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Uid",
                table: "Clientes",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_FornecedorUid",
                table: "Compras",
                column: "FornecedorUid");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_TipoPagamentoUid",
                table: "Compras",
                column: "TipoPagamentoUid");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_Uid",
                table: "Compras",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_Uid",
                table: "Fornecedores",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensCompras_CompraUid",
                table: "ItensCompras",
                column: "CompraUid");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCompras_ProdutoUid",
                table: "ItensCompras",
                column: "ProdutoUid");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCompras_Uid",
                table: "ItensCompras",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensVendas_ProdutoUid",
                table: "ItensVendas",
                column: "ProdutoUid");

            migrationBuilder.CreateIndex(
                name: "IX_ItensVendas_VendaUid",
                table: "ItensVendas",
                column: "VendaUid");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Estoque",
                table: "Produtos",
                column: "Estoque");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Uid",
                table: "Produtos",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoPagamentos_Uid",
                table: "TipoPagamentos",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteUid",
                table: "Vendas",
                column: "ClienteUid");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_TipoPagamentoUid",
                table: "Vendas",
                column: "TipoPagamentoUid");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_Uid",
                table: "Vendas",
                column: "Uid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensCompras");

            migrationBuilder.DropTable(
                name: "ItensVendas");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Clientes")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ClientesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "TipoPagamentos");
        }
    }
}
