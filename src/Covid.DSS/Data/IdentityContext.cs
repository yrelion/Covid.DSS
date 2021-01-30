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

            Seed(modelBuilder);

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

        protected void Seed(ModelBuilder modelBuilder)
        {
            var defaultRoles = new List<IdentityRole>
            {
                new IdentityRole("User")
                {
                    NormalizedName = "USER"
                },
                new IdentityRole("Admin")
                {
                    NormalizedName = "ADMIN"
                },
                new IdentityRole("Support")
                {
                    NormalizedName = "SUPPORT"
                },
            };

            foreach (var identityRole in defaultRoles)
            {
                modelBuilder.Entity<IdentityRole>().HasData(identityRole);
            }

            var userEmail = "user@dss.com";
            var adminEmail = "admin@dss.com";
            var supportEmail = "support@dss.com";

            var defaultPassword = "1234abcd!";

            var defaultUsers = new List<IdentityUser>
            {
                new IdentityUser(userEmail)
                {
                    Email = userEmail,
                    NormalizedEmail = userEmail.ToUpperInvariant(),
                    NormalizedUserName = userEmail.ToUpperInvariant(),
                    EmailConfirmed = true,
                    LockoutEnabled = false
                },
                new IdentityUser(adminEmail)
                {
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpperInvariant(),
                    NormalizedUserName = adminEmail.ToUpperInvariant(),
                    EmailConfirmed = true,
                    LockoutEnabled = false
                },
                new IdentityUser(supportEmail)
                {
                    Email = supportEmail,
                    NormalizedEmail = supportEmail.ToUpperInvariant(),
                    NormalizedUserName = supportEmail.ToUpperInvariant(),
                    EmailConfirmed = true,
                    LockoutEnabled = false
                }
            };

            foreach (var identityUser in defaultUsers)
            {
                identityUser.PasswordHash = HashPassword(identityUser, defaultPassword);
                modelBuilder.Entity<IdentityUser>().HasData(identityUser);
            }

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId = defaultUsers.FirstOrDefault(x => x.UserName == userEmail)?.Id,
                    RoleId = defaultRoles.FirstOrDefault(x => x.Name == "User")?.Id
                },
                new IdentityUserRole<string>
                {
                    UserId = defaultUsers.FirstOrDefault(x => x.UserName == adminEmail)?.Id,
                    RoleId = defaultRoles.FirstOrDefault(x => x.Name == "Admin")?.Id
                },
                new IdentityUserRole<string>
                {
                    UserId = defaultUsers.FirstOrDefault(x => x.UserName == supportEmail)?.Id,
                    RoleId = defaultRoles.FirstOrDefault(x => x.Name == "Support")?.Id
                }
            });
        }

        private string HashPassword<T>(T user, string password) where T : IdentityUser
        {
            var hasher = new PasswordHasher<T>();
            return hasher.HashPassword(user, password);
        }
    }
}
