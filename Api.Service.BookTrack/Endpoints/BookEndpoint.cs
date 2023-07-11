using Api.Service.BookTrack.Extensions;
using Api.Service.BookTrack.Services;
using Interfaces.Models;
using Interfaces.Services;
using Interfaces.Wrappers.Out;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Endpoints
{
    internal class BookEndpoint
    {
        public BookService BookService { get; }

        public BookEndpoint(BookService bookService)
        {
            BookService = bookService;
        }

        [FunctionName("Books")]
        public async Task<IActionResult> Books(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/books")] HttpRequest req,
            ILogger log)
        {
            //todo: validar role do jwt

            var options = new BookOptions();

            if (req.Query.ContainsKey("status_type")) 
                options.FilterStatus = req.Query["status_type"].Select(p => Enum.Parse<EStatusType>(p, true)).ToList();

            var results = await BookService.Books(options).ConfigureAwait(false);

            var wrapper = await WrapperOutBook.From(results).ConfigureAwait(false);
            return new OkObjectResult(wrapper);
        }

        [FunctionName("Book")]
        public async Task<IActionResult> Book(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/book/uid/{bookUid}")] HttpRequest req,
            ILogger log,
            Guid bookUid)
        {
            //todo: validar role do jwt

            var result = await BookService.Book(bookUid, new BookOptions { });
            if (result == null) return new NotFoundObjectResult(new WrapperOutError { Message = "Livro não encontrado" });

            var wrapperOut = await WrapperOutBook.From(result).ConfigureAwait(false);

            return new OkObjectResult(wrapperOut);
        }

        [FunctionName("SearchBook")]
        public async Task<IActionResult> SearchBook(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/search/books")] HttpRequest req,
            ILogger log)
        {
            //todo: validar role do jwt

            var options = new BookOptions();

            if (req.Query.ContainsKey("status_type"))
                options.FilterStatus = req.Query["status_type"].Select(p => Enum.Parse<EStatusType>(p, true)).ToList();
            if (req.Query.ContainsKey("title")) options.FilterTitle = req.Query["title"];

            var results = await BookService.Books(options);

            var wrapperOut = await WrapperOutBook.From(results).ConfigureAwait(false);

            return new OkObjectResult(wrapperOut);
        }

        [FunctionName("Loans")]
        public async Task<IActionResult> Loans(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/loans")] HttpRequest req,
            ILogger log)
        {
            return new OkResult();
        }
    }
}
