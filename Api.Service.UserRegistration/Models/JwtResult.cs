using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Models
{
    public class JwtResult
    {
        public string AccessToken { get; set; }

        public string Type { get; set; }

        public double Expire { get; set; }
    }
}
