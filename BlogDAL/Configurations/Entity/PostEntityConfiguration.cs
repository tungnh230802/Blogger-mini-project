using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogDAL.Models;

namespace BlogDAL.Configurations
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // 1-n:User-post
            builder
             .HasOne(p => p.userPost)
             .WithMany(u => u.posts)
             .HasForeignKey(p => p.authorId);
        }
    }
}
