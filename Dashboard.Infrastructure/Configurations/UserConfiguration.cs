﻿
using Dashboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dashboard.Infrastructure.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(500);

            builder.Property(x => x.IdentityId).HasMaxLength(500);

            builder.Property(x => x.UserName).HasMaxLength(300);

            builder.Property(x => x.Name).HasMaxLength(100);

            builder.HasIndex(x => x.IdentityId).IsUnique();

            builder.HasIndex(x => x.UserName).IsUnique();
        }
    }

}
