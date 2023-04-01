using Api.Service.UserRegistration.Extensions;
using Api.Service.UserRegistration.Models;
using Api.Service.UserRegistration.Models.Wrappers.Out;
using Api.Service.UserRegistration.Services;
using Google.Protobuf.WellKnownTypes;
using Interfaces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Utilities
{
    public static class UserUtilities
    {
        private static string Key
        {
            get
            {
                var jwtKey = Environment.GetEnvironmentVariable("JwtKey");

                if (string.IsNullOrEmpty(jwtKey))
                {
                    jwtKey = "6040E308-8AF2-4639-B7D7-57B405A4DA42-C33BF5B8-B498-4464-9769-FD09388DA06D";
                }

                return jwtKey;
            }
        }

        private const string Issuer = "https://api.userregistration.com.br";

        public static string Audience = "DefaultAudience";

        internal static async Task<IActionResult> JwtResult(UserModel user, HttpRequest req, UserService userService)
        {
            if (user.Blocked) return new BadRequestObjectResult(new WrapperOutError { Message = "Acesso bloqueado." });

            return await CreateJwtResponse(user);
        }
        internal static async Task<IActionResult> CreateJwtResponse(UserModel user)
        {
            var jwtResult = await CreateJwt(user).ConfigureAwait(false);

            var wrapper = new WrapperJwtResult();
            await wrapper.Populate(jwtResult).ConfigureAwait(false);

            return new OkObjectResult(wrapper);
        }

        internal static async Task<JwtResult> CreateJwt(UserModel user)
        {
            var jwtData = new JwtData(user);
            var expireDiff = TimeSpan.FromHours(1);

            var jwtResult = await ToJwt(jwtData, expireDiff);
            return jwtResult;
        }

        public static Task<JwtResult> ToJwt(JwtData data, TimeSpan expireDiff)
        {
            if (data.NotBefore == null) data.NotBefore = DateTime.Now;

            data.ExpireAt = data.NotBefore + expireDiff;

            return ToJwt(data, data.NotBefore.Value, data.ExpireAt.Value);
        }

        public static Task<JwtResult> ToJwt(JwtData data, DateTime createdAt, DateTime expireAt)
        {
            return InternalToJwt(data, createdAt, expireAt);
        }

        private static async Task<JwtResult> InternalToJwt(JwtData data, DateTime createdAt, DateTime expireAt)
        {
            var jwtKey = Encoding.UTF8.GetBytes(Key);
            var securityKey = new SymmetricSecurityKey(jwtKey);
            var claims = await data.AllClaims();
            var identity = new ClaimsIdentity(claims, "OAuth");
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = Issuer,
                Audience = Audience,
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = createdAt,
                Subject = identity,
                NotBefore = createdAt,
                Expires = expireAt
            });

            var result = new JwtResult
            {
                AccessToken = handler.WriteToken(securityToken),
                Expire = expireAt.Timestamp(),
                Type = "Bearer"
            };

            return result;
        }

        public static async Task<JwtData> FromJwt(string jwt, bool validateLifetime = true)
        {
            var info = Validate(jwt, validateLifetime);

            if (info == null) return null;

            var result = new JwtData(info.Claims.ToList())
            {
                Jwt = jwt,
                JwtToken = info,
                NotBefore = info.ValidFrom,
                ExpireAt = info.ValidTo
            };

            await result.CreateUserModel();

            return result;
        }

        

        private static JwtSecurityToken Validate(string token, bool validateLifetime)
        {
            JwtSecurityToken reuslt = null;
            try
            {
                var jwtKey = Encoding.UTF8.GetBytes(Key);
                var tokenHandler = new JwtSecurityTokenHandler();
                var paramsValidation = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = validateLifetime,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
                    ValidAudience = Audience,
                    ValidIssuer = Issuer
                };

                SecurityToken securityToken;
                tokenHandler.ValidateToken(token, paramsValidation, out securityToken);

                reuslt = tokenHandler.ReadJwtToken(token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

            return reuslt;
        }
    }
}
