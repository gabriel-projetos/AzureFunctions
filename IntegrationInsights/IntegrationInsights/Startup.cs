using IntegrationInsights;
using IntegrationInsights.Utility;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

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

            AppDomain.CurrentDomain.GetAssemblies().ToList()
                .ForEach(a => DependencyInjection.Setup(builder, a));
        }
    }
}
