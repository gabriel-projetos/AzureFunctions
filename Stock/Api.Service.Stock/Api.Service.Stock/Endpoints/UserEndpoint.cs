using Api.DigitalPages.Module.Common.Extensions;
using Api.Service.Stock.Models;
using Api.Service.Stock.Services;
using Interfaces.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Endpoints
{
    
    internal class UserEndpoint
    {
        //private UserService UserService { get; }

        //public UserEndpoint(UserService userService)
        //{
        //    UserService = userService;
        //}

        [FunctionName("GetUserRegisters")]
        public async Task<IActionResult> GetUserRegisters(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "user/registers")] HttpRequest req,
            ILogger log)
        {
            var result = await UserService.Get();

            return new OkObjectResult(result);
        }

        //[FunctionName("InsertUserRegisters")]
        //public async Task<IActionResult> InsertUserRegisters(
        //    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "user/registers")] HttpRequest req,
        //    ILogger log)
        //{
        //    var user = await req.BodyDeserialize<CourseUserRegister>();
        //    var result = await UserService.Insert(user);

        //    return new OkObjectResult(result);
        //}

        //[FunctionName("PutUserRegisters")]
        //public async Task<IActionResult> PutUserRegisters(
        //   [HttpTrigger(AuthorizationLevel.Function, "put", Route = "user/registers/{userUid}")] HttpRequest req,
        //   Guid userUid,
        //   ILogger log)
        //{
        //    var userModel = await UserService.Get(userUid, new UserService.UserRegisterOptions());

        //    var json = await req.BodyAsString();
        //    JsonConvert.PopulateObject(json, userModel);


        //    var result = await UserService.Update(userModel);

        //    return new OkObjectResult(result);
        //}

        //[FunctionName("DeleteUserRegisters")]
        //public async Task<IActionResult> DeleteUserRegisters(
        //   [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "user/registers")] HttpRequest req,
        //   ILogger log)
        //{
        //    var result = await UserService.Get();

        //    return new OkObjectResult(result);
        //}
    }
}
