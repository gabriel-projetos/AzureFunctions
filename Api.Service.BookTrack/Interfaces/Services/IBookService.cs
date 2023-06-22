using Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IBookService
    {
        #region froms
        Task<IBook> BookFrom(string json);
        #endregion

        Task<IBook> Create(IBook book);

        Task<IBook> Update(IBook book);

        Task<bool> Delete(Guid uid);

        Task<List<IBook>> Books(BookOptions options);

        Task<IBook> Get(Guid uid, BookOptions options);
    }

    public class BookOptions
    {
        public List<EStatusType> FilterStatus { get; set; }
    }
}
