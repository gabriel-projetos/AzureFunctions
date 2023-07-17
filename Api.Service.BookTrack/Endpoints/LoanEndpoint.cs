using Api.Service.BookTrack.Services;
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
    }
}
