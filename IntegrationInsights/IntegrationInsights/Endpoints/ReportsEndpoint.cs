using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using System.Diagnostics;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace IntegrationInsights.Endpoints
{
    public class ReportsEndpoint
    {
        const string X_API_KEY = "jdcegq36w4lrjnwxmnh11gftloybcz44b7nv4wcy";
        const string ApplicationInsightsId = "02ec0fd6-4a67-4479-a2d3-bd867a0def15";
        private IConfiguration Configuration;

        public ReportsEndpoint(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        [FunctionName("SendLogsInsights")]
        public async Task<IActionResult> SendLogsInsights(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request. Enviando para o insgihts");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";


            var query = "traces | where message contains 'Enviando'";
            var url = $"https://api.applicationinsights.io/v1/apps/f4441da9-232c-477a-beec-7512a0d725f5/query?query={query}";
            var response = await url
                .WithHeader("X-Api-Key", X_API_KEY)
                .WithTimeout(TimeSpan.FromMinutes(5))
                .GetJsonAsync<dynamic>();


            var config = TelemetryConfiguration.CreateDefault();
            config.InstrumentationKey = Configuration.GetConnectionStringOrSetting("APPINSIGHTS_INSTRUMENTATIONKEY");

            var insightsClient = new TelemetryClient(config);

            var evt = new EventTelemetry("Teste de evento");
            evt.Properties.Add("Propriedade", "Valor");
            evt.Properties.Add("JsonData", "Valor");
            evt.Context.GlobalProperties.Add("ContextPropriedade", "Valor");


            insightsClient.TrackEvent(evt);
            insightsClient.Flush();

            return new OkObjectResult(response);
        }
    }
}
