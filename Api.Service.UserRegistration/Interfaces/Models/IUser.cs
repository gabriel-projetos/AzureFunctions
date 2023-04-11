
namespace Interfaces.Models
{
    public interface IUser : IBaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Blocked { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
