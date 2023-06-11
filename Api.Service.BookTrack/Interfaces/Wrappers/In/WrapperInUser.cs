using Interfaces.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Wrappers.In
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

        [JsonProperty("name")]
        public string Name
        {
            get => Data.Name;
            set => Data.Name = value;
        }

        [JsonProperty("email")]
        public string Email
        {
            get => Data.Email;
            set => Data.Email = value;
        }

        [JsonProperty("phone_number")]
        public string PhoneNumber
        {
            get => Data.PhoneNumber;
            set => Data.PhoneNumber = value;
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
