using Api.Service.BookTrack.Extensions;
using Api.Service.BookTrack.Models;
using Api.Service.BookTrack.Services;
using Interfaces.Wrappers.In;
using Interfaces.Wrappers.Out;
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
using static Interfaces.Models.Enums;

namespace Api.Service.BookTrack.Endpoints
{
    internal class UserEndpoint
    {
        public UserService UserService { get; set; }

        public UserEndpoint(UserService userService)
        {
            UserService = userService;
        }

        public List<ERole> ManagementUser = new List<ERole>
        {
            ERole.AdministratorGlobal,
            ERole.PlatformSuper
        };

        [FunctionName("UserCreate")]
        public async Task<IActionResult> UserCreate(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/user")] HttpRequest req,
            ILogger log)
        {
            var jwt = await req.JwtInfo().ConfigureAwait(false);
            if (jwt.Model.HasAnyRole(ManagementUser) == false) return new UnauthorizedResult();

            var wrapperInUser = await req.BodyDeserialize<WrapperInUser<UserModel>>();
            if (wrapperInUser == null) return new BadRequestObjectResult(new WrapperOutError { Message = "Usuário informado inválido"});

            var user = await wrapperInUser.Result().ConfigureAwait(false);

            var result = await UserService.Create(user).ConfigureAwait(false);
            if (result == null) return new BadRequestObjectResult(new WrapperOutError { Message = "Dados inválidos" });

            var wrapperOutUser = await WrapperOutUser.From(result).ConfigureAwait(false);
            return new OkObjectResult(wrapperOutUser);
        }

    }
}
