using Api.Service.Stock.Models;
using Api.Service.Stock.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Data.Configurations.MsSql
{
    internal class ItensCompraMsSqlConfigurations : IEntityTypeConfiguration<ItensCompra>
    {
        public void Configure(EntityTypeBuilder<ItensCompra> modelBuilder)
        {
            DefaultModelSetup.DefaultModelV2Setup(modelBuilder);
            modelBuilder.HasIndex(m => m.Uid).IsUnique();
            modelBuilder.HasOne(d => d.DbProduto)
                .WithMany(p => p.DbItensCompraModel)
                .HasForeignKey(d => d.ProdutoUid)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.HasOne(d => d.DbCompra)
                .WithMany(p => p.DbItensCompraModel)
                .HasForeignKey(d => d.CompraUid)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
