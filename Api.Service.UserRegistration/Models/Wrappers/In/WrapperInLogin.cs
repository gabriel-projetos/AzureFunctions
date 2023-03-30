using Interfaces.Models;
using Newtonsoft.Json;
using System;

namespace Api.Service.UserRegistration.Models.Wrappers.In
{
    public class WrapperInLogin : ILogin
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        internal bool IsValid()
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
        }
    }
}
