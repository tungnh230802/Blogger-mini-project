using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogDAL.Models;
using System;

namespace BlogDAL.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.profile)
                .HasMaxLength(256);
            builder.Property(u => u.intro)
                .HasMaxLength(256);
        }
    }
}
