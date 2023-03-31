using Api.Service.UserRegistration.Context;
using Api.Service.UserRegistration.Models;
using Api.Service.UserRegistration.Utilities;
using Api.Service.UserRegistration.Utilities.Security;
using Interfaces.Models;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
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
        private ApiDbContext Context { get; }

        public UserService(ApiDbContext apiDbContext)
        {
            Context = apiDbContext;
        }

        public async Task<UserModel> Validade(string login, string password)
        {
            var remoteUser = await Context.Users.Where(m => m.Login == login).FirstOrDefaultAsync();

            if (remoteUser != null && !await CorrectPassword(password, remoteUser.Password))
            {
                remoteUser = null;
            };

            return remoteUser;
        }

        public async Task<bool> CorrectPassword(string remotePassword, string localPassword)
        {
            if (remotePassword == null) return false;

            var passwordV1 = SHA1.Hash(remotePassword);

            if (localPassword == passwordV1) return true;
            if (localPassword.StartsWith("$2") && BCrypt.Net.BCrypt.Verify(remotePassword, localPassword)) return true;

            await Task.CompletedTask;

            return false;
        }

        internal async Task<UserModel> LoadUserData(UserModel model)
        {
            var query = Context.Users.Where(m => m.Uid == model.Uid);

            var remoteUser = await query
                //.Include(p => p.DbDetail)
                .FirstOrDefaultAsync().ConfigureAwait(false);

            return remoteUser;
        }
    }
}
