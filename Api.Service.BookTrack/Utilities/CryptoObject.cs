using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Utilities
{
    public class CryptoObject
    {
        private const string SecureCryptoKey = "3309526a-c83c-48fd-b428-2bf0c8b08060";

        //public static async Task<string> SecureSerialize<T>(T data, string cryptoKey = null, int? keyIndex = null)
        //{
        //    cryptoKey = cryptoKey ?? SecureCryptoKey;

        //    var crypto = new CryptoService();
        //    var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
        //    {
        //        ContractResolver = new PropertyRenameAndIgnoreSerializerContractResolver()
        //    });
        //    var bytes = Encoding.UTF8.GetBytes(json);
        //    string result = null;

        //    using (var origin = new MemoryStream(bytes))
        //    using (var dest = new MemoryStream())
        //    {
        //        await crypto.Write(origin, dest, cryptoKey, keyIndex);
        //        dest.Seek(0, SeekOrigin.Begin);

        //        using (var streamCompacted = new MemoryStream())
        //        using (var gzip = new GZipStream(streamCompacted, CompressionMode.Compress))
        //        {
        //            await dest.CopyToAsync(gzip).ConfigureAwait(false);
        //            await gzip.FlushAsync().ConfigureAwait(false);

        //            streamCompacted.Seek(0, SeekOrigin.Begin);
        //            result = Base64UrlEncoder.Encode(streamCompacted.ToArray());
        //        }

        //    }

        //    return result;
        //}

        //public static async Task<T> SecureDeserialize<T>(string data, string cryptoKey = null, bool catchException = true)
        //{
        //    T result = default(T);
        //    cryptoKey = cryptoKey ?? SecureCryptoKey;

        //    try
        //    {
        //        var crypto = new CryptoService();
        //        var bytes = Base64UrlEncoder.DecodeBytes(data);//  Convert.FromBase64String(data);

        //        using (var compStr = new MemoryStream(bytes))
        //        using (var dest = new MemoryStream())
        //        using (var gzip = new GZipStream(compStr, CompressionMode.Decompress))
        //        {
        //            await gzip.CopyToAsync(dest).ConfigureAwait(false);
        //            dest.Seek(0, SeekOrigin.Begin);

        //            using (var streamDecr = await crypto.Open(dest, cryptoKey))
        //            using (var destStream = new MemoryStream())
        //            {
        //                await streamDecr.CopyToAsync(destStream).ConfigureAwait(false);
        //                var json = Encoding.UTF8.GetString(destStream.ToArray());
        //                result = JsonConvert.DeserializeObject<T>(json);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e);

        //        if (catchException == false) throw e;
        //    }

        //    return result;
        //}
    }
}
