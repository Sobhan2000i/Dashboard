﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Infrastructure.Persistence
{
    public sealed class ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : IdentityDbContext(options)
    {
        //public DbSet<RefreshToken> RefreshTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schemas.Identity);


            builder.Entity<IdentityUser>().ToTable("asp_net_users");
            builder.Entity<IdentityRole>().ToTable("asp_net_roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("asp_net_user_roles");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("asp_net_role_claims");
            builder.Entity<IdentityUserClaim<string>>().ToTable("asp_net_user_claims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("asp_net_user_logins");
            builder.Entity<IdentityUserToken<string>>().ToTable("asp_net_user_tokens");

            //builder.Entity<RefreshToken>(entity =>
            //{
            //    entity.HasKey(x => x.Id);

            //    entity.Property(x => x.UserId).HasMaxLength(300);

            //    entity.Property(x => x.Token).HasMaxLength(1000);

            //    entity.HasIndex(x => x.Token).IsUnique();

            //    entity.HasOne(x => x.User)
            //        .WithMany()
            //        .HasForeignKey(x => x.UserId)
            //        .OnDelete(DeleteBehavior.Cascade);
            //});

        }
    }
}
