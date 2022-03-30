using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using projectwebdev.Models;

namespace projectwebdev.Data
{
    public class ApplicationDbInitializer
    {
        private readonly ModelBuilder builder;
        public ApplicationDbInitializer(ModelBuilder builder)
        {
            this.builder = builder;
        }
        
        public void Seed()
        {
            // Admininistrator Role ID
            const string adminRoleId = "2301D884-221A-4E7D-B509-0113DCC043E1";

            // Create the Administrator Role
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = adminRoleId, Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
            );

            // Basic Admin User ID
            const string adminUserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

            // Hasher for creation of basic admin user password
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                // create admin user
                new ApplicationUser() { Id = adminUserId, UserName = "admin@localhost", NormalizedUserName = "ADMIN@LOCALHOST", Email = "admin@localhost", NormalizedEmail = "ADMIN@LOCALHOST", PasswordHash = hasher.HashPassword(null, "root"), EmailConfirmed = true },
                
                // for testing - registered user
                new ApplicationUser() { UserName = "user@localhost", NormalizedUserName = "USER@LOCALHOST", Email = "user@localhost", NormalizedEmail = "USER@LOCALHOST", PasswordHash = hasher.HashPassword(null, "root"), EmailConfirmed = true }
            );

            // Give the Basic admin user the Administrator Role
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });
        }
    }
}