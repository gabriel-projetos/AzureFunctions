using Api.Service.BookTrack.Context.Converts;
using Api.Service.BookTrack.Models;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Interfaces.Models.Enums;

namespace Api.Service.BookTrack.Context
{
    public class ApiServiceDbContext : DbContext
    {
        internal DbSet<UserModel> Users { get; set; }
        internal DbSet<BookModel> Books { get; set; }

        internal DbSet<AuthorizationModel> Authorizations { get; set; }

        public ApiServiceDbContext(DbContextOptions<ApiServiceDbContext> ctx) : base(ctx) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var convertListString = new GenericConvert<List<string>>();

            DefaultModelSetup<UserModel>(modelBuilder);
            modelBuilder.Entity<UserModel>().Property(m => m.Login).IsRequired();
            modelBuilder.Entity<UserModel>().Property(m => m.Password).IsRequired();
            modelBuilder.Entity<UserModel>().Ignore(m => m.Authorizations);
            modelBuilder.Entity<UserModel>().HasIndex(m => m.Login).IncludeProperties(p => p.Password).IsUnique(false);
            modelBuilder.Entity<UserModel>().HasIndex(m => m.Login).IsUnique();

            DefaultModelSetup<BookModel>(modelBuilder);
            modelBuilder.Entity<BookModel>().Property(m => m.Status).HasConversion(new EnumToStringConverter<EStatusType>()).HasMaxLength(50);
            modelBuilder.Entity<BookModel>().Property(m => m.Authors).HasConversion(convertListString).HasMaxLength(1024);

            var valueComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());
            modelBuilder
                .Entity<BookModel>()
                .Property(e => e.Authors)
                .Metadata
                .SetValueComparer(valueComparer);

            DefaultModelSetup<AuthorizationModel>(modelBuilder);
            modelBuilder.Entity<AuthorizationModel>().Property(x => x.Role).HasConversion(new EnumToStringConverter<ERole>());
            modelBuilder.Entity<AuthorizationModel>().HasOne(m => m.DbUser).WithMany(p => p.DbRoles).IsRequired().OnDelete(DeleteBehavior.Cascade);

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
