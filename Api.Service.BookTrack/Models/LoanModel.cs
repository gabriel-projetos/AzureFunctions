using Interfaces.Models;
using System;

namespace Api.Service.BookTrack.Models
{
    public class LoanModel : BaseModel, ILoan
    {
        public BookModel DbBook { get; set; }

        public UserModel DbUser {  get; set; }

        public Guid BookUid { get; set; }

        public Guid UserUid { get; set; }

        public DateTime LoansAt { get; set; }

        public DateTime ReturnAt { get; set; }

        public LoanStatus LoansStatus { get; set; }
    }
}
