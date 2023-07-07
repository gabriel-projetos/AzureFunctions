using Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Interfaces.Models.Enums;

namespace Api.Service.BookTrack.Models
{
    public class AuthorizationModel : BaseModel, IAuthorization
    {
        public ERole Role { get; set; }

        public Guid UserUid { get; set; }

        public UserModel DbUser { get; set; }
    }
}
