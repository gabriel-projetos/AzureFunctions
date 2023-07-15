using Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Service.BookTrack.Models
{
    public class BookModel : BaseModel, IBook
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public DateTime? Publication { get; set; }
        public string Genre { get; set; }
        public string Synopsis { get; set; }
        public int TotalPages { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public EStatusType Status { get; set; }
        public DateTime Acquisition { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesRented { get; set; }
        public byte[] BookCover { get; set; }

        internal List<LoanModel> DbLoans { get; set; }
        public List<ILoan> Loans
        {
            get
            {
                return new List<ILoan>(DbLoans);
            }
            set
            {
                DbLoans = value.Cast<LoanModel>().ToList();
            }
        }

        public BookModel()
        {
            DbLoans = new List<LoanModel>();
        }
    }
}
