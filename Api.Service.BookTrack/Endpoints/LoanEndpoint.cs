using Api.Service.BookTrack.Services;
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

namespace Api.Service.BookTrack.Endpoints
{
    internal class LoanEndpoint
    {
        private BookService BookService { get; }

        private UserService UserService { get; }

        private LoanService LoanService { get; }

        public LoanEndpoint(BookService bookService, UserService userService, LoanService loanService)
        {
            BookService = bookService;
            UserService = userService;
            LoanService = loanService;
        }

        [FunctionName("RequestLoan")]
        public async Task<IActionResult> RequestLoan(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/request/loan")] HttpRequest req,
            ILogger log)
        {
            return new OkResult();
        }
    }
}
