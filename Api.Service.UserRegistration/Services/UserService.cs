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
    public class UserService : IUserService
    {
        private ApiDbContext Context { get; }

        public UserService(ApiDbContext apiDbContext)
        {
            Context = apiDbContext;
        }

        public async Task<UserModel> Validade(string login, string password)
        {
            var remoteUser = await Context.Users.Where(m => m.Login == login).Include(x => x.UserInfo).Include(x => x.Authorizations).FirstOrDefaultAsync();

            if (remoteUser != null && !await CorrectPassword(password, remoteUser.Password))
            {
                remoteUser = null;
            };

            return remoteUser;
        }

        private string ConvertPassword(string password)
        {
            if (password.StartsWith("##no|compute##"))
            {
                return password.Replace("##no|compute##", "");
            }

            return BCrypt.Net.BCrypt.HashPassword(password, 10);
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

        public async Task<UserModel> LoadUserData(UserModel model)
        {
            var query = Context.Users.Where(m => m.Uid == model.Uid);

            var remoteUser = await query
                .Include(p => p.UserInfo)
                .FirstOrDefaultAsync().ConfigureAwait(false);

            return remoteUser;
        }

        public async Task<IUser> UserCreate(IUser user)
        {
            if (user is not UserModel model) return null;

            if (model.Password == null) model.Password = Guid.NewGuid().ToString();

            model.Password = ConvertPassword(model.Password);

            if (model.Authorizations.Count == 0)
            {
                model.Authorizations.Add(new AuthorizationModel { Role = Enums.ERole.Viewer });
            }

            Context.Users.Add(model);
            await Context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> Delete(Guid userUid)
        {
            try
            {
                var models = Context.Users.Where(x => x.Uid == userUid);
                Context.RemoveRange(models);

                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        //Todo
        public Task<IUser> Update(IUser user)
        {
            throw new NotImplementedException();
        }
    }
}
