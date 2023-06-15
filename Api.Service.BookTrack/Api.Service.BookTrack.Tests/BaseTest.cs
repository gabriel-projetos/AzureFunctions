using Api.Service.BookTrack.Context;
using Api.Service.BookTrack.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.BookTrack.Tests
{
    public class BaseTest
    {
        public DbContextOptions<ApiServiceDbContext> CreateContextOptions()
        {
            var ctx = new DbContextOptionsBuilder<ApiServiceDbContext>()
                .UseInMemoryDatabase($"{Guid.NewGuid()}")
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .Options;

            return ctx;
        }

        public ApiServiceDbContext CreateContextInMemory()
        {
            var contextOptions = CreateContextOptions();

            return new ApiServiceDbContext(contextOptions);
        }

        public UserService CreateUserService()
        {
            var context = CreateContextInMemory();
            var service = new UserService(context);
            return service;
        }

        public BookService CreateBookService()
        {
            var context = CreateContextInMemory();
            var service = new BookService(context);
            return service;
        }
    }
}
