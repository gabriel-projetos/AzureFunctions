using Api.Service.BookTrack.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Endpoints
{
    public class SystemEndpoint
    {
        private IServiceProvider ServiceProvider { get; }

        private UserService UserService { get; }

        public SystemEndpoint(IServiceProvider serviceProvider, UserService userService)
        {
            ServiceProvider = serviceProvider;
            UserService = userService;
        }


        [FunctionName("CheckAdminUser")]
        public async Task CheckAdminUser([TimerTrigger("0 */5 * * * *", RunOnStartup = false)] TimerInfo myTimer, ILogger log)
        {
            await SetupAdminUser(log).ConfigureAwait(false);
        }

        private async Task SetupAdminUser(ILogger log)
        {
            string login, password;

            try
            {
                log.LogInformation("Verificando login de plataforma.");
                login = Environment.GetEnvironmentVariable("SuperUserLogin");
                password = Environment.GetEnvironmentVariable("SuperUserPassword");

                _ = await UserService.SetupSuperUser(login, password).ConfigureAwait(false);
                log.LogInformation("Verificação de login de plataforma concluído.");
            }
            catch (Exception e)
            {
                log.LogError(e.ToString());
            }
        }
    }
}
