using Api.Service.UserRegistration.Models;
using Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interfaces.Models.Enums;

namespace Api.Service.UserRegistration.Extensions
{
    public static class UserModelExtension
    {
        public static bool HasAnyRole(this UserModel model, List<ERole> roles)
        {
            if (model == null)
            {
                return false;
            }

            bool flag = false;
            foreach (var role in model.Authorizations)
            {
                flag = roles.Contains(role.Role);
                if (flag)
                {
                    break;
                }
            }

            return flag;
        }
    }
}
