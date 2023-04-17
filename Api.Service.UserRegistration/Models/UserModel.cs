using Interfaces.Models;
using System.Collections.Generic;

namespace Api.Service.UserRegistration.Models
{
    public class UserModel : BaseModel, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Blocked { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserInfoModel UserInfo { get; set; }

        public List<AuthorizationModel> Authorizations { get; set; }
    }
}
