using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Tests.Utilities
{
    internal static class AssemblyUtility
    {
        public static async Task<string> LoadWithString(string fileName)
        {
            var assembly = typeof(AssemblyUtility).Assembly;

            var file = assembly.GetManifestResourceNames().ToList().Find(p => p.EndsWith(fileName));
            var jsonStream = assembly.GetManifestResourceStream(file);
            var streamReader = new StreamReader(jsonStream);
            var json = await streamReader.ReadToEndAsync().ConfigureAwait(false);

            return json;
        }
    }
}
