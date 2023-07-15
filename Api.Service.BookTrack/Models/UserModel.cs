using Interfaces.Models;
using System.Collections.Generic;
using System.Linq;

namespace Api.Service.BookTrack.Models
{
    public class UserModel : BaseModel, IUser
    {
        public string Login { set; get; }
        public string Name { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public bool Blocked { set; get; }
        public string LastName { set; get; }
        public string FirstName { set; get; }

        internal List<AuthorizationModel> DbRoles { get; set; }
        public List<IAuthorization> Authorizations 
        { 
            get
            {
                return new List<IAuthorization>(DbRoles);
            }
            set
            {
                DbRoles = value.Cast<AuthorizationModel>().ToList();
            }
        }

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

        public UserModel()
        {
            DbRoles = new List<AuthorizationModel>();
            DbLoans = new List<LoanModel>();
        }
    }
}
