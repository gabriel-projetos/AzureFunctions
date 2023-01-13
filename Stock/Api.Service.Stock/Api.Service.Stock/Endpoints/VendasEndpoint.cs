using Api.Service.Stock.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Endpoints
{
    public class VendasEndpoint
    {
        private VendaService VendaService { get; }

        public VendasEndpoint(VendaService vendaService)
        {
            VendaService = vendaService;
        }

        [FunctionName("GetTipoPagamento")]
        public async Task<IActionResult> GetTipoPagamento(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "tipo/pagamento")] HttpRequest req,
            ILogger log)
        {
            var result = await VendaService.GetTipoPagamentos();

            return new OkObjectResult(result);
        }
    }
    

}
