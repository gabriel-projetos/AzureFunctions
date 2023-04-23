using Api.Service.UserRegistration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Interfaces.Models.Enums;

namespace Api.Service.UserRegistration.Context
{
    public class ApiDbContext : DbContext
    {

        internal DbSet<UserModel> Users { get; set; }
        internal DbSet<UserInfoModel> UserInfos { get; set; }
        internal DbSet<AuthorizationModel> Authorizations { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> ctx) : base(ctx)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DefaultModelSetup<UserModel>(modelBuilder);
            modelBuilder.Entity<UserModel>().Property(m => m.Login).IsRequired();
            modelBuilder.Entity<UserModel>().Property(m => m.Password).IsRequired();
            modelBuilder.Entity<UserModel>().HasIndex(m => m.Login).IncludeProperties(p => p.Password).IsUnique(false);
            modelBuilder.Entity<UserModel>().HasIndex(m => m.Login).IsUnique();
            modelBuilder.Entity<UserModel>().HasOne(m => m.UserInfo).WithOne(x => x.User).HasForeignKey<UserInfoModel>(x => x.UserUid);
            modelBuilder.Entity<UserModel>().HasMany(x => x.Authorizations).WithOne(x => x.User).HasForeignKey(x => x.UserUid);
            modelBuilder.Entity<UserModel>().ToTable(nameof(Users), b => b.IsTemporal()); //https://learn.microsoft.com/pt-br/ef/core/what-is-new/ef-core-6.0/whatsnew#configuring-a-temporal-table

            DefaultModelSetup<UserInfoModel>(modelBuilder);

            DefaultModelSetup<AuthorizationModel>(modelBuilder);
            modelBuilder.Entity<AuthorizationModel>().Property(x => x.Role).HasConversion(new EnumToStringConverter<ERole>());
            modelBuilder.Entity<AuthorizationModel>().ToTable(nameof(Authorizations), b => b.IsTemporal());
        }

        public override int SaveChanges()
        {
            AdjustChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int result;
            try
            {
                AdjustChanges();
                result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                RollBack();
                throw;
            }

            return result;
        }

        public void RollBack()
        {
            var changedEntries = ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        private void AdjustChanges()
        {
            var changes = ChangeTracker.Entries<BaseModel>().Where(p => p.State == EntityState.Modified || p.State == EntityState.Added);

            foreach (var entry in changes)
            {
                entry.Property(p => p.UpdatedAt).CurrentValue = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Property(p => p.CreatedAt).CurrentValue = DateTime.UtcNow;
                }
            }
        }

        public void DefaultModelSetup<T>(ModelBuilder modelBuilder) where T : BaseModel
        {
            modelBuilder.Entity<T>().Property(m => m.CreatedAt).IsRequired();
            modelBuilder.Entity<T>().Property(m => m.UpdatedAt).IsRequired();
            modelBuilder.Entity<T>().HasKey(m => m.Uid);
            modelBuilder.Entity<T>().HasIndex(m => m.Uid).IsUnique();
            modelBuilder.Entity<T>().Property(m => m.Uid).IsRequired().HasDefaultValueSql("NEWSEQUENTIALID()").ValueGeneratedOnAdd();
        }
    }
}
