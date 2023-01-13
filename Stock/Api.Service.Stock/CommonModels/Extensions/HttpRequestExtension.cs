using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DigitalPages.Module.Common.Extensions
{
    public static class HttpRequestExtension
    {

        public static async Task<T> BodyDeserialize<T>(this HttpRequest request)
        {
            T result = default(T);

            try
            {
                var data = await request.BodyAsString().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<T>(data);
            }
            catch(Exception e)
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

        public static async Task<string> ClientIp(this HttpRequest request)
        {
            var ip = await request.FindKey("Client-Ip", null);
            var forwarded = await request.FindKey("X-Forwarded-For", null);

            if (forwarded != null)
            {
                ip = forwarded.Split(",").FirstOrDefault();
            }

            return ip;
        }

        public static Task<string> ProjectKey(this HttpRequest request)
        {
            return request.FindKey("Project-Key", "project_key");
        }

        public static Task<string> InstanceUid(this HttpRequest request)
        {
            return request.FindKey("Api-Instance-Uid", "api_instance_uid");
        }
        

        public static Task<string> Enviroment(this HttpRequest request)
        {
            return request.FindKey("Api-Env", "api_env");
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
