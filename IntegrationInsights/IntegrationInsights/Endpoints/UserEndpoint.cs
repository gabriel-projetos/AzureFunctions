using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IntegrationInsights.Services;
using IntegrationInsights.SqlDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IntegrationInsights.Endpoints
{
    internal class UserEndpoint
    {
        private UserService UserService { get; set; }

        public UserEndpoint(UserService userService)
        {
            UserService = userService;
        }
        
        [FunctionName("UserEndpoint")]
        public async Task<IActionResult> User(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "user")]
            HttpRequest req, ILogger log)
        {
            var users = await UserService.GetUsers();

            return new OkObjectResult(users);
        }
    }
}
