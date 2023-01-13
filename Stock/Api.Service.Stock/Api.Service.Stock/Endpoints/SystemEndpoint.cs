using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Stock.Endpoints
{
    internal class SystemEndpoint
    {
        [FunctionName("CheckApplication")]
        public static async Task CheckApplication([TimerTrigger("0 0 * * * *", RunOnStartup = true, UseMonitor = false)] TimerInfo myTimer, ILogger log)
        {
            var factors = FindAllAssignableFrom<IDesignTimeDbContextFactory<DbContext>>();

            foreach (var type in factors)
            {
                try
                {
                    var instance = Activator.CreateInstance(type) as IDesignTimeDbContextFactory<DbContext>;
                    if (instance == null) continue;

                    var context = instance.CreateDbContext(new string[0]);
                    var pending = await context.Database.GetPendingMigrationsAsync().ConfigureAwait(false);

                    if (pending.Count() == 0) continue;

                    await context.Database.MigrateAsync().ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    var message = e.ToString();
                    if (message.Contains("Value cannot be null. (Parameter 'connectionString')") == false)
                    {
                        log.LogError(e.ToString());
                    }
                }


            }
        }

        public static List<Type> FindAllAssignableFrom<T>() where T : class
        {
            var result = AppDomain.CurrentDomain.GetAssemblies().ToList()
                .SelectMany(p => p.DefinedTypes
                    .ToList()
                    .FindAll(t => t.IsAbstract == false && typeof(T)
                    .IsAssignableFrom(t.AsType()))
                    .Select(t => t.AsType()))
                .ToList();

            return result;
        }
    }
}
