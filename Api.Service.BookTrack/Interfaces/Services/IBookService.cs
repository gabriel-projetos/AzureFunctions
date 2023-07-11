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
        Task<IBook> BookFrom(string json, IBook? baseModel = null);
        #endregion

        Task<IBook> Create(IBook book);

        Task<IBook> Update(IBook book);

        Task<bool> Delete(Guid uid);

        Task<List<IBook>> Books(BookOptions options);

        Task<IBook> Book(Guid uid, BookOptions options);
    }

    public class BookOptions
    {
        public List<EStatusType>? FilterStatus { get; set; }

        public string? FilterTitle { get; set; }

        public string? FilterAuthor { get; set; }

        public string? FilterISBN { get; set; }

        public string? FilterPublisher { get; set; }

        public DateTime? FilterPublication { get; set; }

        public string? FilterGenre { get; set; }

        public string? FilterLanguage { get; set; }
    }
}
