using Api.Service.BookTrack.Models;
using Api.Service.BookTrack.Services;
using Interfaces.Models;
using Interfaces.Wrappers.In;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Tests.ServicesTests
{
    public class BookServiceTest : BaseTest
    {
        private readonly BookService BookService;

        public BookServiceTest()
        {
            BookService = CreateBookService();
        }

        [Fact]
        public void ShouldCreateBookService()
        {
            Assert.NotNull(BookService);
        }

        [Fact]
        public async void ShouldCreateBook()
        {
            //arrange
            var model = new BookModel
            {
                Title = "Test",
                TotalPages = 1
            };

            //act
            var json = JsonConvert.SerializeObject(new WrapperInBook<IBook>(model));
            var book = await BookService.BookFrom(json);

            book = await BookService.Create(book);

            //assert
            Assert.NotNull(book);
            Assert.Equal("Test", book.Title);
            Assert.Equal(1, book.TotalPages);
        }
    }
}
