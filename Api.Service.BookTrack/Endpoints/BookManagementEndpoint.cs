using Api.Service.BookTrack.Extensions;
using Api.Service.BookTrack.Services;
using Interfaces.Services;
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

namespace Api.Service.BookTrack.Endpoints
{
    internal class BookManagementEndpoint
    {
        public BookService BookService { get; }

        public BookManagementEndpoint(BookService bookService)
        {
            BookService = bookService;
        }

        [FunctionName("DeleteBook")]
        public async Task<IActionResult> DeleteBook(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "v1/book/uid/{bookUid}/management")] HttpRequest req,
            ILogger log,
            Guid bookUid)
        {
            //todo validar jwt

            var book = await BookService.Book(bookUid, new BookOptions { });
            if (book == null) return new BadRequestObjectResult(new WrapperOutError { Message = "Livro não encontrado" });

            var result = await BookService.Delete(bookUid);
            if (result == false) return new BadRequestObjectResult(new WrapperOutError { Message = "Falha ao deletar livro" });

            return new NoContentResult();
        }

        [FunctionName("UpdateBook")]
        public async Task<IActionResult> UpdateBook(
           [HttpTrigger(AuthorizationLevel.Function, "put", Route = "v1/book/uid/{bookUid}/management")] HttpRequest req,
           ILogger log,
           Guid bookUid)
        {
            //todo: validar role do jwt

            var book = await BookService.Book(bookUid, new BookOptions { }).ConfigureAwait(false);
            if (book == null) return new NotFoundObjectResult(new WrapperOutError { Message = "Livro não encontrado" });

            var json = await req.BodyAsString().ConfigureAwait(false);

            var bookIn = await BookService.BookFrom(json, book);
            if (bookIn == null) return new BadRequestObjectResult(new WrapperOutError { Message = "Estrutura de dados inválida" });

            book = await BookService.Update(book).ConfigureAwait(false);

            var result = await WrapperOutBook.From(book).ConfigureAwait(false);
            return new ObjectResult(result);
        }

        [FunctionName("BookCreate")]
        public async Task<IActionResult> BookCreate(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/book/management")] HttpRequest req,
            ILogger log)
        {
            //todo: validar role do jwt.

            var json = await req.BodyAsString().ConfigureAwait(false);

            var book = await BookService.BookFrom(json);
            if (book == null) return new BadRequestObjectResult(new WrapperOutError { Message = "Livro informado inválido" });

            var result = await BookService.Create(book).ConfigureAwait(false);
            if (result == null) return new BadRequestObjectResult(new WrapperOutError { Message = "Dados inválidos" });

            var wrapper = await WrapperOutBook.From(result).ConfigureAwait(false);

            return new OkObjectResult(wrapper);
        }
    }
}
