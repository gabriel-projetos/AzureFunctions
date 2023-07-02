using Interfaces.Wrappers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Jwt
{
    public class WrapperJwtResult : Wrapper<JwtResult>
    {
        [JsonProperty("access_token")]
        public string AccessToken
        {
            get => Data.AccessToken;
            set => Data.AccessToken = value;
        }

        [JsonProperty("expire")]
        public double Expire
        {
            get => Data.Expire;
            set => Data.Expire = value;
        }

        [JsonProperty("type")]
        public string Type
        {
            get => Data.Type;
            set => Data.Type = value;
        }
    }
}
