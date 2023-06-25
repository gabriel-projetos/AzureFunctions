using Api.Service.BookTrack.Context;
using Api.Service.BookTrack.Ioc;
using Api.Service.BookTrack.Models;
using Interfaces.Models;
using Interfaces.Services;
using Interfaces.Wrappers.In;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Services
{
    [Ioc(Interface = typeof(BookService))]
    public class BookService : IBookService
    {
        private ApiServiceDbContext Context { get; }

        public BookService(ApiServiceDbContext context)
        {
            Context = context;
        }

        #region froms
        public async Task<IBook> BookFrom(string json, IBook baseModel = null)
        {
            BookModel model = baseModel as BookModel;
            if (model == null) model = new BookModel();

            var wr = await WrapperInBook<BookModel>.From(model);
            JsonConvert.PopulateObject(json, wr);

            if (wr.IsValid() == false) return null;

            var result = await wr.Result().ConfigureAwait(false);
            return result;
        }
        #endregion

        public async Task<List<IBook>> Books(BookOptions options)
        {
            var result = await Query(options).ToListAsync<IBook>().ConfigureAwait(false);

            return result;
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

        public Task<IBook> Book(Guid uid, BookOptions options)
        {
            throw new NotImplementedException();
        }

        public Task<IBook> Update(IBook book)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BookModel> Query(BookOptions options)
        {
            var query = Context.Books.AsQueryable();

            if (options?.FilterStatus != null) query = query.Where(x => options.FilterStatus.Contains(x.Status));

            return query;
        }
    }
}
