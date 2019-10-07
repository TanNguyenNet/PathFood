using CV.Core.Data;
using CV.Data.Entities;
using CV.Data.Entities.Blog;
using CV.Data.Entities.FAQ;
using CV.Data.Entities.Identity;
using CV.Utils.Contants;
using CV.Utils.Helper;
using CV.Utils.Utils.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Reflection;

namespace CV.Data.EF
{
    public sealed partial class CVContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public readonly int CommandTimeoutInSecond = 20 * 60;

        public CVContext(DbContextOptions options) : base(options)
        {
            Database.SetCommandTimeout(CommandTimeoutInSecond);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added || e.State == EntityState.Deleted);

            foreach (EntityEntry item in modified)
            {
                var changedOrAddedItem = item.Entity as AuditTable;
                if (changedOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.CreatedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                    }
                    if (item.State == EntityState.Modified)
                    {
                        changedOrAddedItem.LastUpdatedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                    }
                    if (item.State == EntityState.Deleted)
                    {
                        changedOrAddedItem.DeletedTime = CoreHelper.SystemTimeNowUTCTimeZoneLocal;
                    }
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Identity Config

            builder.Entity<IdentityUserClaim<string>>().ToTable("AppUserClaims").HasKey(x => x.Id);

            builder.Entity<IdentityRoleClaim<string>>().ToTable("AppRoleClaims").HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<string>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });

            builder.Entity<IdentityUserToken<string>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });

            #endregion Identity Config

            builder.Entity<AppUser>().HasQueryFilter(x => x.DeletedDate == null);

            builder.Entity<CategoryBlog>().HasQueryFilter(x => x.DeletedTime == null);

            builder.Entity<Post>().HasQueryFilter(x => x.DeletedTime == null);

            builder.Entity<Question>().HasQueryFilter(x => x.DeletedTime == null);

            builder.Entity<GroupQuestion>().HasQueryFilter(x => x.DeletedTime == null);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot config =
                    new ConfigurationBuilder()
                        .AddJsonFile(ConfigurationFileName.ConnectionConfig, false, true)
                        .Build();

                var connectionString =
                    config.GetValueByEnv<string>(ConfigurationSectionName.ConnectionStrings);

                optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly(typeof(CVContext).GetTypeInfo().Assembly.GetName().Name);

                    sqlServerOptionsAction.MigrationsHistoryTable("Migration");
                });
            }
        }


    }
}