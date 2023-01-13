using Api.Service.CepsMongoDb;
using Api.Service.CepsMongoDb.Service;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
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
namespace Api.Service.CepsMongoDb
{
    internal class Startup : FunctionsStartup
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

            builder.Services.AddSingleton<CepDbContext>();
        }
    }
}
