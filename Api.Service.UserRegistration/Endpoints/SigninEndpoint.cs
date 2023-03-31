using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Api.Service.UserRegistration.Utilities;
using Api.Service.UserRegistration.Models.Wrappers.In;
using Api.Service.UserRegistration.Models.Wrappers.Out;
using Api.Service.UserRegistration.Services;

namespace Api.Service.UserRegistration.Endpoints
{
    internal class SigninEndpoint
    {
        public UserService UserService { get; }

        public SigninEndpoint(UserService userService)
        {
            UserService = userService;
        }


        [FunctionName("SigninUid")]
        public async Task<IActionResult> SigninUid(
          [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/signin/uid")] HttpRequest req,
          [DurableClient] IDurableEntityClient entityClient,
          ILogger log)
        {
            var user = await req.BodyDeserialize<WrapperInLogin>().ConfigureAwait(false);
            if (!user.IsValid()) return new BadRequestObjectResult(new WrapperOutError { Message = "Dado de login ou senha inválido." });

            var remoteUser = await UserService.Validade(user.Login, user.Password).ConfigureAwait(false);
            if (remoteUser == null) return new UnauthorizedResult();

            var response = await UserUtilities.JwtResult(remoteUser, req, UserService).ConfigureAwait(false);

            return response;
        }
    }
}
