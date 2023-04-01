using Interfaces.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
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

        public JwtData(List<Claim> claims)
        {
            AdditionalClaims = claims ?? new List<Claim>();
        }

        public JwtSecurityToken JwtToken { get; set; }
        
        public List<Claim> AdditionalClaims { get; set; } = new List<Claim>();

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
        
        public async Task CreateUserModel()
        {
            var data = new UserModel();

            foreach (var clam in AdditionalClaims.ToList())
            {
                var remove = true;

                switch (clam.Type)
                {
                    
                    case ClaimUserUid:
                        {
                            data.Uid = Guid.Parse(clam.Value);
                            break;
                        }
                    default:
                        {
                            remove = false;
                            break;
                        }
                }

                if (!remove) break;

                AdditionalClaims.Remove(clam);
            }

            Model = data;

            await Task.CompletedTask;
        }
    }
}
