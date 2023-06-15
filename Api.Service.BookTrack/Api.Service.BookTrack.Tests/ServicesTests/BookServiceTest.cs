using Api.Service.BookTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Tests.ServicesTests
{
    public class BookServiceTest : BaseTest
    {
        [Fact]
        public async Task ShouldCreateBookService()
        {
            BookService bookService = CreateBookService();

            Assert.NotNull(bookService);
        }
    }
}
