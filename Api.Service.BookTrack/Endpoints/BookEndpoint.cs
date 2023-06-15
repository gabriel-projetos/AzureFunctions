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

        [FunctionName("BookCreate")]
        public async Task<IActionResult> BookCreate(
            [HttpTrigger(AuthorizationLevel.Function, "post", "v1/book")] HttpRequest req,
            ILogger log)
        {
            var wr = await req.BodyDeserialize<WrapperInBook<BookModel>>();
            if (wr == null) return new BadRequestObjectResult(new WrapperOutError { Message = "Livro informado inválido" });

            var book = await wr.Result().ConfigureAwait(false);

            var result = await BookService.Create(book).ConfigureAwait(false);
            if (result == null) return new BadRequestObjectResult(new WrapperOutError { Message = "Dados inválidos" });

            //var wrapperOut = await WrapperOut

            return new OkObjectResult(result);
        }
    }
}
