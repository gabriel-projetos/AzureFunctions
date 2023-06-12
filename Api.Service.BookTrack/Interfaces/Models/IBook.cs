using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IBook : IBaseModel
    {
        string Title { get; set; }

        List<string> Authors { get; set; }

        /// <summary>
        /// O International Standard Book Number (ISBN) é um código único que identifica o livro.
        /// </summary>
        string ISBN { get; set; }

        string Publisher { get; set; }

        DateTime Publication { get; set; }

        string Genre { get; set; }

        string Synopsis { get; set; }

        int TotalPages { get; set; }

        string Language { get; set; }

        string Location { get; set; }

        string Status { get; set; }

        DateTime Acquisition { get; set; }

        int TotalCopies { get; set; }

        int CopiesRented { get; set; }

        byte[] BookCover { get; set; }
    }
}
