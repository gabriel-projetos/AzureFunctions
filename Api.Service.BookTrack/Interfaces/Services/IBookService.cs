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
        Task<IBook> Create(IBook book);

        Task<IBook> Update(IBook book);

        Task<bool> Delete(Guid uid);

        Task<IBook> Books(BookOptions options);

        Task<IBook> Get(Guid uid, BookOptions options);
    }

    public class BookOptions
    {

    }
}
