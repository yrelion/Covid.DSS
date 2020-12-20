using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Covid.DSS.Data
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Shorten key length for Identity
            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(36);
                entity.Property(m => m.Email).HasMaxLength(255);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(255);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(128);
                entity.Property(m => m.UserName).HasMaxLength(128);
            });
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(36);
                entity.Property(m => m.Name).HasMaxLength(128);
                entity.Property(m => m.NormalizedName).HasMaxLength(128);
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(36);
                entity.Property(m => m.LoginProvider).HasMaxLength(128);
                entity.Property(m => m.ProviderKey).HasMaxLength(128);
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(36);
                entity.Property(m => m.RoleId).HasMaxLength(36);
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(36);
                entity.Property(m => m.LoginProvider).HasMaxLength(128);
                entity.Property(m => m.Name).HasMaxLength(128);

            });
        }
    }
}
