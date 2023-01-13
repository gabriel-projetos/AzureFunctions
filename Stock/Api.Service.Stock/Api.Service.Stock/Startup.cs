using Api.Service.Stock;
using Api.Service.Stock.Context;
using Api.Service.Stock.Utility;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(Startup))]
namespace Api.Service.Stock
{
    public class Startup : FunctionsStartup
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        
        private JsonSerializerSettings JsonSettings()
        {
            return new JsonSerializerSettings
            {
                CheckAdditionalContent = true
            };
        }
        
        public override void Configure(IFunctionsHostBuilder builder)
        {
            JsonConvert.DefaultSettings = JsonSettings;

            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
            #if DEBUG
               .AddJsonFile("local.settings.json", true)
            #endif
               .AddEnvironmentVariables()
               .Build();

            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                builder.Services.AddDbContext<SharedDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {

                switch (config.GetConnectionStringOrSetting("DatabaseProvider"))
                {
                    case "MsSql":
                        // ConnectionString cadastrado em host/local.json utilizado para conectar ao banco.
                        var msSqlConnection = config.GetConnectionStringOrSetting("MsSqlConnection");

                        // Caso exista a configuração de conexão com o banco, o contexto de banco é configurado. 
                        if (!string.IsNullOrEmpty(msSqlConnection))
                        {
                            builder.Services.AddDbContext<SharedDbContext, MsSqlDbContext>();
                        }
                        break;

                    case "OracleConnection":
                        var oracleSqlConnection = config.GetConnectionStringOrSetting("OracleConnection");

                        if (!string.IsNullOrEmpty(oracleSqlConnection))
                        {
                            builder.Services.AddDbContext<SharedDbContext, OracleDbContext>(options =>
                            {
                                //options.UseOracle(oracleSqlConnection, b => b.UseOracleSQLCompatibility("11"));
                                //
#if DEBUG
                                options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                                options.EnableSensitiveDataLogging(true);
                                options.UseLoggerFactory(MyLoggerFactory);
#endif
                            });
                        };
                        
                    break;
                }
            }
            AppDomain.CurrentDomain.GetAssemblies().ToList()
                .ForEach(a => DependencyInjection.Setup(builder, a));
        }
    }
}
