using IntegrationInsights;
using IntegrationInsights.SqlDbContext;
using IntegrationInsights.Utility;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[assembly: FunctionsStartup(typeof(Startup))]
namespace IntegrationInsights
{
    public class Startup : FunctionsStartup
    {
        //private static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
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

            // Caso exista a configuração de conexão com o banco, o contexto de banco é configurado. 
            if (!string.IsNullOrEmpty(sqlConnection))
            {
                builder.Services.AddDbContextPool<IntegrationInsightsDbContext>(options =>
                {
                    options.UseSqlServer(sqlConnection);
                    options.EnableServiceProviderCaching(true);
                    options.EnableDetailedErrors(true);
#if DEBUG
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                    options.EnableSensitiveDataLogging(true);
#endif
                    //options.SetupProvider();
                });
            }

            AppDomain.CurrentDomain.GetAssemblies().ToList()
                .ForEach(a => DependencyInjection.Setup(builder, a));
        }
    }
}
