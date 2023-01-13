using Api.Service.Stock.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Utility
{
    public static class DefaultModelSetup
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
