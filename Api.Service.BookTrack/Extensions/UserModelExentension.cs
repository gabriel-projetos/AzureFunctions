using Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interfaces.Models.Enums;

namespace Api.Service.BookTrack.Extensions
{
    public static class UserModelExentension
    {
        public static bool HasAnyRole(this IUser model, List<ERole> roles)
        {
            if (model == null) return false;

            var result = false;

            foreach (var permission in model.Authorizations)
            {
                result = roles.Contains(permission.Role);

                if (result) break;
            }

            return result;
        }
    }
}
