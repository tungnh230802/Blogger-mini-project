using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogDAL.Configurations;
using BlogDAL.Extension;

namespace BlogDAL.Models
{
    public class BlogContext : IdentityDbContext<AppUser>
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

            RemoveAspPrefix(builder);

            builder.ApplyConfiguration(new PostEntityConfiguration());
            builder.ApplyConfiguration(new CommentEntityConfiguration());
            builder.ApplyConfiguration(new UserEntityConfiguration());

            //seed data
            builder.Seed();
        }

        private static void RemoveAspPrefix(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }
        #endregion

        #region Properties
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        #endregion
    }
}
