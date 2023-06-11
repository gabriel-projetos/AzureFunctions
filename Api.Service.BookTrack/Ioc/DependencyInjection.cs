using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Ioc
{
    public class DependencyInjection
    {
        public static void Setup(IFunctionsHostBuilder builder, Assembly assembly)
        {
            var types = assembly.DefinedTypes;

            foreach (var type in types)
            {
                if (type.IsAbstract) continue;

                var iocAtts = type.GetCustomAttributes(typeof(IocAttribute), false);
                var singletonAtts = type.GetCustomAttributes(typeof(SingletonAttribute), false);

                foreach (var ioc in iocAtts)
                {
                    if (ioc is IocAttribute att)
                    {
                        builder.Services.AddScoped(att.Interface, type);
                    }
                }

                foreach (var singleton in singletonAtts)
                {
                    if (singleton is SingletonAttribute att)
                    {
                        builder.Services.AddSingleton(att.Interface, type);
                    }
                }
            }
        }
    }
}
