using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface IUser : IBaseModel
    {
        string Login { get; set; }

        string Name { get; set; }

        string LastName { get; set; }

        string FirstName { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        string PhoneNumber { get; set; }

        bool Blocked { get; set; }

        List<IAuthorization> Authorizations { get; set; }

        List<ILoan> Loans { get; set; }
    }
}
