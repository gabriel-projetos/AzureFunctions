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
    internal class ItensVendaMsSqlConfigurations : IEntityTypeConfiguration<ItensVenda>
    {
        public void Configure(EntityTypeBuilder<ItensVenda> modelBuilder)
        {
            DefaultModelSetup.DefaultModelV2Setup(modelBuilder);
            modelBuilder.HasOne(d => d.DbProduto)
               .WithMany(p => p.DbItensVendasModel)
               .HasForeignKey(d => d.ProdutoUid)
               .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.HasOne(d => d.DbVenda)
                .WithMany(p => p.DbItensVendasModel)
                .HasForeignKey(d => d.VendaUid)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
