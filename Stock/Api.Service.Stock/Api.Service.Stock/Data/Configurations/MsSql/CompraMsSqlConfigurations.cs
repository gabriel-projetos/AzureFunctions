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

    internal class CompraMsSqlConfigurations : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> modelBuilder)
        {
            DefaultModelSetup.DefaultModelV2Setup(modelBuilder);
            modelBuilder.HasIndex(m => m.Uid).IsUnique();
            modelBuilder.HasOne(d => d.DbFornecedorModel)
                    .WithMany(p => p.DbComprasModel)
                    .HasForeignKey(d => d.FornecedorUid);
            modelBuilder.HasOne(d => d.DbTipoPagamentoModel)
                    .WithMany(p => p.DbComprasModel)
                    .HasForeignKey(d => d.TipoPagamentoUid);
        }
    }
}
