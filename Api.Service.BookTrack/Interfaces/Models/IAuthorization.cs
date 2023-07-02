using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Interfaces.Models.Enums;

namespace Interfaces.Models
{
    public interface IAuthorization : IBaseModel
    {
        ERole Role { get; set; }
    }
}
