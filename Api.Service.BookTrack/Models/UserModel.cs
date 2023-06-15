﻿using Interfaces.Models;

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
    }
}