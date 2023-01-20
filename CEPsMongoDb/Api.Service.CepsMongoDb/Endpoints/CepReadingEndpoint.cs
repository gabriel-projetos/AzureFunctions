using Api.Service.CepsMongoDb.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Api.Service.CepsMongoDb.Models;
using Flurl.Http;

namespace Api.Service.CepsMongoDb.Endpoints
{
    public class CepReadingEndpoint
    {
        //https://viacep.com.br/
        const string VIA_CEP_URL = "https://viacep.com.br/ws/{0}/json/";

        private readonly CepDbContext DBManager;

        public CepReadingEndpoint(CepDbContext dbManager)
        {
            DBManager = dbManager;
        }

        [FunctionName("CreateCepReading")]
        public async Task<IActionResult> CreateCepReading([HttpTrigger(AuthorizationLevel.Function, "post", Route = "cep/reading")] HttpRequest req, 
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

                var request = string.Format(VIA_CEP_URL, requestBody);

                var cepReading = JsonConvert.DeserializeObject<CepModel>(requestBody);

                await DBManager.AddAddressCep(cepReading);
                
                return new OkObjectResult(cepReading);
            }
            catch (Exception e)
            {
                var objectResult = new ObjectResult(e.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
                return objectResult;
            }
        }

        [FunctionName("GetCepReading")]
        public async Task<IActionResult> GetCepReading([HttpTrigger(AuthorizationLevel.Function, "get", Route = "cep/reading")] HttpRequest req,
            ILogger log)
        {
            try
            {
                string cep = req.Query["cep"];

                CepModel cepReading = await DBManager.GetAddressCep(cep);
                if (cepReading == null)
                {
                    cepReading = await FindCepWeb(cep);
                    if (cepReading == null) return new BadRequestObjectResult(new { error = "CEP não encontrado" });

                    await DBManager.AddAddressCep(cepReading);
                }

                return new OkObjectResult(cepReading);
            }
            catch (Exception e)
            {
                var objectResult = new ObjectResult(e.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
                return objectResult;
            }
        }

        //todo: percorrer lista de ceps para inserir na base

        private static async Task<CepModel> FindCepWeb(string cep)
        {
            var url = string.Format(VIA_CEP_URL, cep);

            var flurrequest = await url.GetAsync();
            var request = flurrequest.ResponseMessage;

            var cepReading = JsonConvert.DeserializeObject<CepModel>(await request.Content.ReadAsStringAsync());
            return cepReading;
        }
    }
}
