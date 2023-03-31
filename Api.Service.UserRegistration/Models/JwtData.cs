using Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Models
{
    public class JwtData
    {
        private const string ClaimUserUid = "user_uid";
        private const string ClaimEmail = "email";

        public JwtData(IUser model)
        {
            Model = model;
        }
        
        public IUser Model { get; set; }

        public string Jwt { get; set; }

        public DateTime? NotBefore { get; set; }

        public DateTime? ExpireAt { get; set; }

        public async Task<List<Claim>> AllClaims()
        {
            var claims = new List<Claim>();

            if (Model == null) return claims;

            //claims.Add(new Claim(ClaimEmail, Model.Detail.EmailPrincipal ?? ""));
            //claims.Add(new Claim(ClaimName, Model.Detail.Name ?? ""));
            claims.Add(new Claim(ClaimUserUid, Model.Uid.ToString()));

            //foreach (var permission in Model.Roles)
            //{
            //    claims.Add(new Claim(ClaimRole, permission.Type.ToString()));
            //}

            return claims;
        }
    }
}
