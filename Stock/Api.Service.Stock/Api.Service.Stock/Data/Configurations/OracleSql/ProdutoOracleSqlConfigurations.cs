using Api.Service.Stock.Models;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Data.Configurations.OracleSql
{
    internal class ProdutoOracleSqlConfigurations : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> modelBuilder)
        {
            DefaultModel.DefaultModelV2Setup(modelBuilder);
            modelBuilder.HasIndex(m => m.Uid).IsUnique();
            modelBuilder.HasIndex(m => m.Estoque);
            modelBuilder.Property(m => m.Status).HasConversion(new EnumToStringConverter<EStatus>()).HasMaxLength(50);
        }
    }

    public static class DefaultModel
    {
        public static void DefaultModelV2Setup<T>(EntityTypeBuilder<T> modelBuilder, bool registerKey = true) where T : BaseData
        {
            modelBuilder.Property(m => m.CreatedAt).IsRequired();
            modelBuilder.Property(m => m.UpdatedAt).IsRequired();

            modelBuilder.HasKey(m => m.Uid);
            modelBuilder.Property(m => m.Uid).IsRequired().HasDefaultValueSql("NEWSEQUENTIALID()").ValueGeneratedOnAdd();

        }
    }
}
