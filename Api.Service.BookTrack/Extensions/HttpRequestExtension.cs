﻿using Api.Service.BookTrack.Models;
using Api.Service.BookTrack.Utilities;
using Interfaces.Jwt;
using Interfaces.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interfaces.Models.Enums;

namespace Api.Service.BookTrack.Extensions
{
    public static class HttpRequestExtension
    {
        public const string AuthorizationKey = "Authorization";

        public const string AuthorizationQueryKey = "access_token";

        public static async Task<T> BodyDeserialize<T>(this HttpRequest request)
        {
            T result = default;

            try
            {
                var data = await request.BodyAsString().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return result;
        }

        public static async Task<string> BodyAsString(this HttpRequest request)
        {
            string result = null;

            try
            {
                using (var sr = new StreamReader(request.Body))
                {
                    result = await sr.ReadToEndAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return result;
        }

        public static async Task<JwtData> JwtInfo(this HttpRequest request, bool validateLifeTime = true)
        {
            JwtData result = new JwtData(new UserModel
            {
                Uid = Guid.Empty,
                Authorizations = new List<IAuthorization>
                {
                    new AuthorizationModel
                    {
                        Role = ERole.Annonymos
                    }
                }
            });

            try
            {
                var token = await request.Jwt();


                var response = await UserUtilities.FromJwt(token, validateLifeTime).ConfigureAwait(false);

                if (response != null) result = response;

                //result.Model = await UserUtilities.AdjustUserRolesFromContext(result.Model, inSecureConnection, clientIp);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
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

        public static async Task<string> Jwt(this HttpRequest request)
        {
            var result = await request.FindKey(AuthorizationKey, AuthorizationQueryKey);

            if (!string.IsNullOrEmpty(result))
            {
                result = result.Replace("Bearer ", "");
            }

            return result;
        }
    }
}
