using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogDAL.Configurations;
using BlogDAL.Extension;
using Microsoft.AspNetCore.Identity;
using System;

namespace BlogDAL.Models
{
    public class BlogContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        #region Constructor
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
        #endregion

        #region Method
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PostEntityConfiguration());
            builder.ApplyConfiguration(new CommentEntityConfiguration());
            builder.ApplyConfiguration(new UserEntityConfiguration());
            ConfigIdentiy(builder);

            //seed data
            builder.Seed();
        }

        private static void ConfigIdentiy(ModelBuilder builder)
        {
            const string Claims = "AppUserClaims";
            const string Roles = "AppUserRoles";
            const string UserLogins = "AppUserLogins";
            const string RoleClaims = "AppRoleClaims";
            const string UserTokens = "AppUserTokens";

            builder.Entity<IdentityUserClaim<Guid>>().ToTable(Claims);
            builder.Entity<IdentityUserRole<Guid>>().ToTable(Roles).HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().ToTable(UserLogins).HasKey(x => x.UserId);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable(RoleClaims);
            builder.Entity<IdentityUserToken<Guid>>().ToTable(UserTokens).HasKey(x => x.UserId);
        }

        #endregion

        #region Properties
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        #endregion
    }
}
