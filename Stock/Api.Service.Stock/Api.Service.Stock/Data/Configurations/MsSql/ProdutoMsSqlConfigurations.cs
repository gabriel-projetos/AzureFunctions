using Api.Service.Stock.Models;
using Api.Service.Stock.Utility;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Data.Configurations.MsSql
{
    internal class ProdutoMsSqlConfigurations : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> modelBuilder)
        {
            DefaultModelSetup.DefaultModelV2Setup(modelBuilder);
            modelBuilder.HasIndex(m => m.Uid).IsUnique();
            modelBuilder.HasIndex(m => m.Estoque);
            modelBuilder.Property(m => m.Status).HasConversion(new EnumToStringConverter<EStatus>()).HasMaxLength(50);
        }
    }
}
