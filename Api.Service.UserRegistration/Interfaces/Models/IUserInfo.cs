
namespace Interfaces.Models
{
    public interface IUserInfo : IBaseModel
    {
        string Email { get; set; }
        
        string Phone { get; set; }
    }
}
