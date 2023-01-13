using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Context
{
    public class OracleDbContext : SharedDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Environment.GetEnvironmentVariable("MsSqlConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var namespaces = new[] { "Api.Service.Stock.Data.Configurations", "Api.Service.Stock.Data.Configurations.OracleSql" };
            ApplyConfiguration(modelBuilder, namespaces);
        }
    }
}
