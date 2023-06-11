using Api.Service.BookTrack;
using Api.Service.BookTrack.Context;
using Api.Service.BookTrack.Ioc;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Api.Service.BookTrack
{
    public class Startup : FunctionsStartup
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
                .AddJsonFile("local.settings.json", true)
#endif
                .AddEnvironmentVariables()
                .Build();

            var sqlConnection = config.GetConnectionStringOrSetting("SqlConnectionString");

            if (string.IsNullOrEmpty(sqlConnection) == false)
            {
                builder.Services.AddDbContextPool<ApiServiceDbContext>(options =>
                {
                    options.UseSqlServer(sqlConnection, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
                    options.EnableServiceProviderCaching(true);
                    options.EnableDetailedErrors(true);
#if DEBUG
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                    options.EnableSensitiveDataLogging(true);
                    options.UseLoggerFactory(MyLoggerFactory);
#endif
                });
            }

            builder.Services.AddSingleton(typeof(IConfigurationRoot), config);

            AppDomain.CurrentDomain.GetAssemblies()
                .Where(p => p.FullName.StartsWith("Api.Service")).ToList()
                .ForEach(a => DependencyInjection.Setup(builder, a));
        }
    }
}
