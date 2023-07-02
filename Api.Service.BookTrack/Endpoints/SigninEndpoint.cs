using Api.Service.BookTrack.Services;
using Interfaces.Services;
using Interfaces.Wrappers.Out;
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
using Api.Service.BookTrack.Extensions;
using Interfaces.Wrappers.In;
using Api.Service.BookTrack.Utilities;

namespace Api.Service.BookTrack.Endpoints
{
    public class SigninEndpoint
    {
        private UserService UserService { get; }

        public SigninEndpoint(UserService userService)
        {
            UserService = userService;
        }

        [FunctionName("Signin")]
        public async Task<IActionResult> Signin(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/signin")] HttpRequest req,
            ILogger log)
        {
            var user = await req.BodyDeserialize<WrapperInLogin>().ConfigureAwait(false);
            if (user.IsValid() == false) return new BadRequestObjectResult(new WrapperOutError { Message = "Dados de login ou senha inválido." });

            var remoteUser = await UserService.Validade(user.Login, user.Password).ConfigureAwait(false);
            if (remoteUser == null) return new UnauthorizedResult();

            var response = await UserUtilities.JwtResult(remoteUser, req, UserService).ConfigureAwait(false);

            return response;
        }
    }
}
