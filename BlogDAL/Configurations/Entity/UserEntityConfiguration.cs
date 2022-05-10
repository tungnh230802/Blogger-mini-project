using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogDAL.Models;
using System;

namespace BlogDAL.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.profile)
                .HasMaxLength(256);
            builder.Property(u => u.intro)
                .HasMaxLength(256);

            builder.Property(u => u.registerAt)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
