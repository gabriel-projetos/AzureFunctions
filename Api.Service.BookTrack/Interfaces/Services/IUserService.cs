using Interfaces.Models;

namespace Interfaces.Services
{
    public interface IUserService
    {
        Task<IUser> Create(IUser user);

        Task<IUser> Update(IUser user);

        Task<bool> Delete(Guid userUid);

        Task<IUser> Users();
    }
}
