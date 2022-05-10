using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogDAL.Models;

namespace BlogDAL.Configurations
{
    public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            // 1-n:post-comment
            builder.
                HasOne(c => c.post)
                .WithMany(p => p.comments)
                .HasForeignKey(c => c.postId);
            // 1-n:comment-comment
            builder
                .HasOne(c => c.comment)
                .WithMany(c => c.comments)
                .HasForeignKey(c => c.parentId);

            // 1-n:User-Comment
            builder
                .HasOne(c => c.userComment)
                .WithMany(u => u.comments)
                .HasForeignKey(c => c.userId);

            builder.Property(c => c.userId)
                .IsRequired();
        }
    }
}
