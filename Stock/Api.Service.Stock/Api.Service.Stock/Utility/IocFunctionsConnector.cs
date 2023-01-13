using Interfaces.Annotations;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Api.Service.Stock.Utility
{
    public class DependencyInjection
    {
        public static void Setup(IFunctionsHostBuilder builder)
        {
            var assembly = typeof(DependencyInjection).Assembly;
            Setup(builder, assembly);
        }

        public static void Setup(IFunctionsHostBuilder builder, Assembly assembly)
        {
            var types = assembly.DefinedTypes;

            foreach (var type in types)
            {
                if (type.IsAbstract) continue;

                var iocAtts = type.GetCustomAttributes(typeof(IocAttribute), false);
                var singletonAtts = type.GetCustomAttributes(typeof(SingletonAttribute), false);

                foreach(var ioc in iocAtts)
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

                if (type.FullName.ToLower().Contains("connector"))
                {
                    var ss = 1;
                }
            }
        }
    }
}