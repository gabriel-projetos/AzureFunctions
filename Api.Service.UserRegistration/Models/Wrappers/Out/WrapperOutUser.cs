using Interfaces.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Models.Wrappers.Out
{
    public class WrapperOutUser : WrapperBase<IUser, WrapperOutUser>
    {
        public WrapperOutUser(IUser model) : base(model)
        {
        }
        public WrapperOutUser() : base(null) { }


        [JsonProperty("uid")]
        public Guid Uid
        {
            get => Data.Uid;
            set => Data.Uid = value;
        }

        [JsonProperty("first_name")]
        public string FirstName
        {
            get => Data.FirstName;
            set => Data.FirstName = value;
        }

        [JsonProperty("last_name")]
        public string LastName
        {
            get => Data.LastName;
            set => Data.LastName = value;
        }

        [JsonProperty("blocked")]
        public bool Blocked
        {
            get => Data.Blocked;
            set => Data.Blocked = value;
        }

        [JsonProperty("login")]
        public string Login
        {
            get => Data.Login;
            set => Data.Login = value;
        }

        [JsonProperty("created_at")]
        public DateTime CreatedAt
        {
            get => Data.CreatedAt;
            set => Data.CreatedAt = value;
        }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt
        {
            get => Data.UpdatedAt;
            set => Data.UpdatedAt = value;
        }

        //todo adiciona role no wrapper
        //todo adicionar userInfo no wrapper
    }
}
