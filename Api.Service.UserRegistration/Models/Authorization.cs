using Interfaces.Models;

namespace Api.Service.UserRegistration.Models
{
    public class Authorization : BaseModel, IAuthorization
    {
        public Enums.ERole Role { get; set; }
    }
}
