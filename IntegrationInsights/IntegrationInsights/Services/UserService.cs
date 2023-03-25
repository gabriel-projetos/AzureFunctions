using IntegrationInsights.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IntegrationInsights.Models;
using IntegrationInsights.SqlDbContext;
using Microsoft.EntityFrameworkCore;

namespace IntegrationInsights.Services
{
    [Ioc(Interface = typeof(UserService))]
    public class UserService
    {
        private IntegrationInsightsDbContext Context;

        public UserService(IntegrationInsightsDbContext context)
        {
            Context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await Context.Users.ToListAsync();
        }
    }
}
