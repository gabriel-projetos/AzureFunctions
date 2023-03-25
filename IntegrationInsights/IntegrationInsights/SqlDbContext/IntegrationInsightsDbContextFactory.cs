using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IntegrationInsights.SqlDbContext
{
    internal class IntegrationInsightsDbContextFactory : IDesignTimeDbContextFactory<IntegrationInsightsDbContext>
    {
        public IntegrationInsightsDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", true)
                .AddEnvironmentVariables()
                .Build();

            var connection = config.GetConnectionStringOrSetting("SqlConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<IntegrationInsightsDbContext>();
            optionsBuilder.UseSqlServer(connection);

            return new IntegrationInsightsDbContext(optionsBuilder.Options);
        }
    }
}
