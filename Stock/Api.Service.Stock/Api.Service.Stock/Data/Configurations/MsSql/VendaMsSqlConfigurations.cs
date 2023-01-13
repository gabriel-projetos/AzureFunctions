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
    internal class VendaMsSqlConfigurations : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> modelBuilder)
        {
            DefaultModelSetup.DefaultModelV2Setup(modelBuilder);
            modelBuilder.HasIndex(m => m.Uid).IsUnique();
            modelBuilder.HasOne(d => d.DbCliente)
                    .WithMany(p => p.DbVendasModel)
                    .HasForeignKey(d => d.ClienteUid);
            modelBuilder.HasOne(d => d.DbTipoPagamento)
                    .WithMany(p => p.DbVendasModel)
                    .HasForeignKey(d => d.TipoPagamentoUid);
        }
    }
}
