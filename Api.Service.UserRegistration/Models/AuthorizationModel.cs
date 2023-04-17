using Interfaces.Models;
using System;

namespace Api.Service.UserRegistration.Models
{
    public class AuthorizationModel : BaseModel, IAuthorization
    {
        public Enums.ERole Role { get; set; }

        public Guid UserUid { get; set; }

        public UserModel User { get; set; }
    }
}
