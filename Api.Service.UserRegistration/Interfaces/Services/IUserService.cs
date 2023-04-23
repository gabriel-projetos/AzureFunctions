using Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IUserService
    {
        Task<IUser> UserCreate(IUser user);

        Task<bool> Delete(Guid userUid);
    }
}
