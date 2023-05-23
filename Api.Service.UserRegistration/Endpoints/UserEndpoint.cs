using Api.Service.UserRegistration.Models;
using Api.Service.UserRegistration.Services;
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
using Api.Service.UserRegistration.Extensions;
using Api.Service.UserRegistration.Utilities;
using Api.Service.UserRegistration.Models.Wrappers.In;
using Api.Service.UserRegistration.Models.Wrappers.Out;
using Interfaces.Models;
using static Interfaces.Models.Enums;

namespace Api.Service.UserRegistration.Endpoints
{
    internal class UserEndpoint
    {
        public List<ERole> ManagementUsers = new()
        {
            ERole.Admin
        };

        public UserService UserService { get; }

        public UserEndpoint(UserService userService)
        {
            UserService = userService;
        }

        [FunctionName("UserCreate")]
        public async Task<IActionResult> UserCreate(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/user")] HttpRequest req,
            ILogger log)
        {
            var jwt = await req.JwtInfo().ConfigureAwait(false);

            var user = await req.BodyDeserialize<WrapperInUser<UserModel>>();
            if (user == null) new BadRequestObjectResult(new WrapperOutError { Message = "Dados inválidos."});

            var result = await UserService.UserCreate(await user.Result()).ConfigureAwait(false);
            if (result == null) return new BadRequestObjectResult(new WrapperOutError { Message = "Dados inválidos." });

            var wr = await WrapperOutUser.From(result).ConfigureAwait(false);

            return new OkObjectResult(wr);
        }

        [FunctionName("UserDelete")]
        public async Task<IActionResult> UserDelete(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "v1/user/uid/{userUid}")] HttpRequest req,
            ILogger log,
            Guid userUid)
        {
            var jwt = await req.JwtInfo().ConfigureAwait(false);
            if (jwt.Model.HasAnyRole(ManagementUsers) == false) return new UnauthorizedResult();

            var result = await UserService.Delete(userUid).ConfigureAwait(false);
            if (result == false) return new BadRequestResult();

            return new OkResult();
        }

        [FunctionName("UserUpdate")]
        public async Task<IActionResult> UserUpdate(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "v1/user")] HttpRequest req,
            ILogger log)
        {
            var jwt = await req.JwtInfo().ConfigureAwait(false);
            if (jwt.Model.Uid == Guid.Empty) return new UnauthorizedResult();

            var user = await req.BodyDeserialize<WrapperInUser<UserModel>>();
            if (user == null) new BadRequestObjectResult(new WrapperOutError { Message = "Dados inválidos." });

            var result = await UserService.Update(await user.Result()).ConfigureAwait(false);
            if (result == null) return new BadRequestObjectResult(new WrapperOutError { Message = "Dados inválidos." });

            var wr = await WrapperOutUser.From(result).ConfigureAwait(false);

            return new OkObjectResult(wr);
        }
    }
}
