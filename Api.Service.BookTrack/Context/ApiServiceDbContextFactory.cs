using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Context
{
    internal class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiServiceDbContext>
    {
        public ApiServiceDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", true)
                .AddEnvironmentVariables()
                .Build();

            var connection = config.GetConnectionStringOrSetting("SqlConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<ApiServiceDbContext>();
            optionsBuilder.UseSqlServer(connection);

            return new ApiServiceDbContext(optionsBuilder.Options);
        }
    }
}
