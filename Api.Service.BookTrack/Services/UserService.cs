using Api.Service.BookTrack.Context;
using Api.Service.BookTrack.Ioc;
using Api.Service.BookTrack.Models;
using Interfaces.Models;
using Interfaces.Services;
using System;
using System.Threading.Tasks;

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

            //convert password

            Context.Users.Add(model);
            await Context.SaveChangesAsync();

            return model;
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
