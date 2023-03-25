using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using IntegrationInsights.Models;

namespace IntegrationInsights.SqlDbContext
{
    public class IntegrationInsightsDbContext : DbContext
    {
        internal DbSet<User> Users { get; set; }

        public IntegrationInsightsDbContext(DbContextOptions<IntegrationInsightsDbContext> ctx) : base(ctx)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey((Expression<Func<User, object>>)(m => (object)m.Uid));
            modelBuilder.Entity<User>().Property<Guid>((Expression<Func<User, Guid>>)(m => m.Uid)).IsRequired(true).HasDefaultValueSql<Guid>("NEWSEQUENTIALID()").ValueGeneratedOnAdd();
        }
    }
}
