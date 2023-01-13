using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Context
{
    public class MsSqlDbContext : SharedDbContext
    {
       // public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
               .AddJsonFile("local.settings.json", true)
#endif
               .AddEnvironmentVariables()
               .Build();
            options.UseSqlServer(config.GetConnectionStringOrSetting("MsSqlConnection"));
            options.EnableDetailedErrors(true);
#if DEBUG
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            options.EnableSensitiveDataLogging(true);
            //options.UseLoggerFactory(MyLoggerFactory);
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var namespaces = new[] { "Api.Service.Stock.Data.Configurations", "Api.Service.Stock.Data.Configurations.MsSql" };
            ApplyConfiguration(modelBuilder, namespaces);
        }
    }
}
