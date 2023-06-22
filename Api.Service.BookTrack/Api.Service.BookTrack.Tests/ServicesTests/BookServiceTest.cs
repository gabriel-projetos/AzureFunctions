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
        public void ShouldCreateBookService()
        {
            BookService bookService = CreateBookService();

            Assert.NotNull(bookService);
        }

        [Fact]
        public void ShouldCreateBookModel()
        {

        }
    }
}
