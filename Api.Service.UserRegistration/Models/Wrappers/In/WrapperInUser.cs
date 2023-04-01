using Interfaces.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Models.Wrappers.In
{
    public class WrapperInUser<TUser> : WrapperBase<TUser, WrapperInUser<TUser>>
        where TUser : IUser
    {
        public WrapperInUser() : base() { }

        public WrapperInUser(TUser data) : base(data) { }

        [JsonProperty("first_name")]
        public string FirstName
        {
            get => Data.FirstName;
            set => Data.FirstName = value;
        }

        [JsonProperty("last_name")]
        public string LastName
        {
            get => Data.LastName;
            set => Data.LastName = value;
        }

        [JsonProperty("login")]
        public string Login
        {
            get => Data.Login;
            set => Data.Login = value;
        }

        [JsonProperty("password")]
        public string Password
        {
            get => Data.Password;
            set => Data.Password = value;
        }
    }
}
