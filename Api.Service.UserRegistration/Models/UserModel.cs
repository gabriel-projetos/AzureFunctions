using Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Models
{
    public class UserModel : BaseModel, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Blocked { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
