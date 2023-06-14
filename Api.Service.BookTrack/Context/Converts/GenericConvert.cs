using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Context.Converts
{
    public class GenericConvert<TInput> : ValueConverter<TInput, string>
    {
        public GenericConvert() : base(v => CustomConvertToProvider(v), v => CustomConvertFromProvider(v))
        {

        }

        private static TInput CustomConvertFromProvider(string arg)
        {
            var result = default(TInput);

            try
            {
                result = JsonConvert.DeserializeObject<TInput>(arg);
            }
            catch (Exception)
            {
                try
                {
                    //considera  que o dado foi salvo inicialmente criptografado
                    //result = CryptoObject.SecureDeserialize<TInput>(arg, SecurityConvert<TInput>.SecurityContentKey, catchException: false).Result;
                }
                catch (Exception ee)
                {
                    Debug.WriteLine(ee);
                }
            }

            return result;
        }

        private static string CustomConvertToProvider(TInput arg)
        {
            return JsonConvert.SerializeObject(arg);
        }
    }
}
