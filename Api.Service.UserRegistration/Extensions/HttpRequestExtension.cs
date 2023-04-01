using Api.Service.UserRegistration.Models;
using Api.Service.UserRegistration.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Extensions
{
    public static class HttpRequestExtension
    {
        public const string AuthorizationKey = "Authorization";

        public const string AuthorizationQueryKey = "access_token";

        public static async Task<JwtData> JwtInfo(this HttpRequest request, bool validateLifeTime = true)
        {
            JwtData result = new JwtData(new UserModel
            {
                Uid = Guid.Empty
            });

            try
            {
                var token = await request.Jwt();

                var response = await UserUtilities.FromJwt(token, validateLifeTime).ConfigureAwait(false);

                if (response != null) result = response;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return result;
        }

        public static async Task<string> Jwt(this HttpRequest request)
        {
            var result = await request.FindKey(AuthorizationKey, AuthorizationQueryKey);

            if (!string.IsNullOrEmpty(result))
            {
                result = result.Replace("Bearer ", "");
            }

            return result;
        }

        public static Task<string> FindKey(this HttpRequest request, string headerKey, string queryKey)
        {
            string result = null;

            try
            {
                if (!string.IsNullOrEmpty(headerKey))
                {
                    result = request.Headers.Where(p => p.Key.ToLower() == headerKey.ToLower())?.Select(p => p.Value)?.FirstOrDefault();
                }

                if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(queryKey))
                {
                    result = request.Query.Where(p => p.Key.ToLower() == queryKey.ToLower())?.Select(p => p.Value)?.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return Task.FromResult(result);
        }
    }
}
