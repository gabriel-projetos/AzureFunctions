using Api.Service.BookTrack.Context;
using Api.Service.BookTrack.Ioc;
using Api.Service.BookTrack.Models;
using Interfaces.Models;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Services
{
    [Ioc(Interface = typeof(BookService))]
    internal class BookService : IBookService
    {
        private ApiServiceDbContext Context { get; }

        public BookService(ApiServiceDbContext context)
        {
            Context = context;
        }

        public Task<IBook> Books(BookOptions options)
        {
            throw new NotImplementedException();
        }

        public async Task<IBook> Create(IBook book)
        {
            if (book is not BookModel model) return null;

            Context.Books.Add(model);
            await Context.SaveChangesAsync();

            return model;
        }

        public Task<bool> Delete(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<IBook> Get(Guid uid, BookOptions options)
        {
            throw new NotImplementedException();
        }

        public Task<IBook> Update(IBook book)
        {
            throw new NotImplementedException();
        }
    }
}
