using Api.Service.UserRegistration.Context;
using Api.Service.UserRegistration.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.UserRegistration.Tests
{
    public class BaseTest
    {
        public DbContextOptions<ApiDbContext> CreateContextOptions()
        {
            var ctx = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase($"{Guid.NewGuid()}")
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .Options;

            return ctx;
        }

        public ApiDbContext CreateContextInMemory()
        {
            var contextOptions = CreateContextOptions();

            return new ApiDbContext(contextOptions);
        }

        public UserService CreateUserService()
        {
            var context = CreateContextInMemory();
            var service = new UserService(context);
            return service;
        }
    }
}
