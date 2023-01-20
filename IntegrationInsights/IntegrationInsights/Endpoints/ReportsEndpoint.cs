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

namespace IntegrationInsights.Endpoints
{
    public class ReportsEndpoint
    {
        const string X_API_KEY = "jdcegq36w4lrjnwxmnh11gftloybcz44b7nv4wcy";
        const string ApplicationInsightsId = "02ec0fd6-4a67-4479-a2d3-bd867a0def15";


        [FunctionName("SendLogsInsights")]
        public static async Task<IActionResult> SendLogsInsights(
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
            var url = $"https://api.applicationinsights.io/v1/apps/{ApplicationInsightsId}/query?query={query}";
            var response = await url
                .WithHeader("X-Api-Key", X_API_KEY)
                .WithTimeout(TimeSpan.FromMinutes(5))
                .GetJsonAsync<dynamic>();

            return new OkObjectResult(response);
        }
    }
}
