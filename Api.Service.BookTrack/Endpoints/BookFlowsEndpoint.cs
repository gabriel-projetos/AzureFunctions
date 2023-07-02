using Api.Service.BookTrack.Services;

namespace Api.Service.BookTrack.Endpoints
{
    public class BookFlowsEndpoint
    {
        private BookService BookService { get; }

        public BookFlowsEndpoint(BookService bookService)
        {
            BookService = bookService;
        }
    }
}
