using Interfaces.Models;
using static Interfaces.Models.Enums;

namespace Interfaces.Models
{
    public interface IAuthorization : IBaseModel
    {
        ERole Role { get; set; }
    }
}
