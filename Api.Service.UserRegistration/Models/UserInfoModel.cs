using Interfaces.Models;
using System;

namespace Api.Service.UserRegistration.Models
{
    public class UserInfoModel : BaseModel, IUserInfo
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid UserUid { get; set; }
        public UserModel User { get; set; }
    }
}
