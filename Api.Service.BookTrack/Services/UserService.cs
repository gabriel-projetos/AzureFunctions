using Api.Service.BookTrack.Context;
using Api.Service.BookTrack.Ioc;
using Api.Service.BookTrack.Models;
using Api.Service.BookTrack.Utilities.Security;
using Interfaces.Models;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Interfaces.Models.Enums;

namespace Api.Service.BookTrack.Services
{
    [Ioc(Interface = typeof(UserService))]
    public class UserService : IUserService
    {
        private ApiServiceDbContext Context { get; }

        public UserService(ApiServiceDbContext apiDbContext)
        {
            Context = apiDbContext;
        }

        public async Task<IUser> Create(IUser user)
        {
            if (user is not UserModel model) return null;

            if (model.Password == null) model.Password = Guid.NewGuid().ToString();

            model.Password = ConvertPassword(model.Password);

            Context.Users.Add(model);
            await Context.SaveChangesAsync();

            return model;
        }

        public async Task<UserModel> Validade(string login, string password)
        {
            var remoteUser = await Context.Users.Where(m => m.Login == login).Include(x => x.DbRoles).FirstOrDefaultAsync();

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

        public async Task<UserModel> SetupSuperUser(string login, string password)
        {
            var platformUsers = await Context.Users.Where(p => p.DbRoles.Any(r => r.Role == ERole.PlatformSuper)).ToListAsync();
            var removeUsers = platformUsers.Where(p => p.Login != login).ToList();
            var currentUser = platformUsers.FirstOrDefault(p => p.Login == login);
            var updated = false;

            if (removeUsers.Count > 0)
            {
                Context.Users.RemoveRange(removeUsers);
                updated = true;
            }

            password = ConvertPassword(password);

            if (currentUser == null)
            {
                var sufix = Guid.NewGuid().ToString();
                var name = $"SuperUser-{sufix.Substring(0, 5)}";
                var permission = new AuthorizationModel { Role = ERole.PlatformSuper };
                currentUser = new UserModel
                {
                    Login = login,
                    Password = password,
                    //DbDetail = new UserDetailModel
                    //{
                    //    Name = name,
                    //    FirstName = name
                    //},
                    Authorizations = new List<IAuthorization>
                    {
                        permission
                    }
                };

                await Context.Users.AddAsync(currentUser).ConfigureAwait(false);
                updated = true;
            }
            else if (currentUser.Password != password || currentUser.Blocked)
            {
                currentUser.Password = password;
                currentUser.Blocked = false;
                Context.Users.Update(currentUser);
                updated = true;
            }

            if (updated)
            {
                await Context.SaveChangesAsync().ConfigureAwait(false);
            }

            return currentUser;
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

        public Task<bool> Delete(Guid userUid)
        {
            throw new NotImplementedException();
        }

        public Task<IUser> Update(IUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<IUser> Users()
        {
            throw new System.NotImplementedException();
        }
    }
}
