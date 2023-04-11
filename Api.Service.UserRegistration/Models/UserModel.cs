using Interfaces.Models;

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
    }
}
