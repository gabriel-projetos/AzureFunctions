using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public class Enums
    {
        [Flags]
        public enum ERole
        {
            Annonymos,
            Admin,
            Viewer,
            PlatformSuper,
            AdministratorGlobal
        }
    }
}
