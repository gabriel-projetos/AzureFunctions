using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Utilities
{
    public static class HttpRequestExtension
    {
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
    }
}
