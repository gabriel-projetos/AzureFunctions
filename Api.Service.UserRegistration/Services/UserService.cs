using Api.Service.UserRegistration.Context;
using Api.Service.UserRegistration.Utilities;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Services
{
    [Ioc(Interface = typeof(UserService))]
    internal class UserService : IUserService
    {
        private ApiDbContext ApiDbContext { get; }

        public UserService(ApiDbContext apiDbContext)
        {
            ApiDbContext = apiDbContext;
        }

        
    }
}
