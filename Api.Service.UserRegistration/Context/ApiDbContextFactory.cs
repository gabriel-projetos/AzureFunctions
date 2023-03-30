using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Context
{
    internal class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", true)
                .AddEnvironmentVariables()
                .Build();

            var connection = config.GetConnectionStringOrSetting("SqlConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
            optionsBuilder.UseSqlServer(connection);

            return new ApiDbContext(optionsBuilder.Options);
        }
    }
}
