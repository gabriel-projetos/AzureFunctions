using Api.Service.UserRegistration.Models.Wrappers.In;
using Api.Service.UserRegistration.Models;
using Api.Service.UserRegistration.Services;
using Api.Service.UserRegistration.Tests.Utilities;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api.Service.UserRegistration.Tests.Services
{
    public class UserServiceTest : BaseTest
    {
        [Fact]
        public async Task ShouldReturnNullIfUserIsNull()
        {
            //Arrange
            UserService service = CreateUserService();

            //act
            var user = await service.UserCreate(null);

            //assert
            Assert.Null(user);
        }

        

        [Fact]
        public async Task ShouldCreateUser()
        {
            //Arrange
            UserService service = CreateUserService();
            
            var json = await AssemblyUtility.LoadWithString("user.json");
            var model = await (JsonConvert.DeserializeObject<WrapperInUser<UserModel>>(json)).Result();

            //act
            var user = await service.UserCreate(model);

            //assert
            Assert.Equal("Micaeles", user.FirstName);
            Assert.Equal("Rossi", user.LastName);
            Assert.Equal("gabriel", user.Login);
            Assert.Equal("123", user.Password);
        }
    }
}
