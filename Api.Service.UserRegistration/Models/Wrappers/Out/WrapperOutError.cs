using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Models.Wrappers.Out
{
    public class WrapperOutError
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
