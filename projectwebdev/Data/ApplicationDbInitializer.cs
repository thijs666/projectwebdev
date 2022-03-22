using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            const string adminRoleId = "2301D884-221A-4E7D-B509-0113DCC043E1";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = adminRoleId, Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
            );

            const string adminUserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(
                // admin user
                new IdentityUser() { Id = adminUserId, UserName = "admin@localhost", NormalizedUserName = "ADMIN@LOCALHOST", Email = "admin@localhost", NormalizedEmail = "ADMIN@LOCALHOST", PasswordHash = hasher.HashPassword(null, "root"), EmailConfirmed = true },
                
                // registered user
                new IdentityUser() { UserName = "user@localhost", NormalizedUserName = "USER@LOCALHOST", Email = "user@localhost", NormalizedEmail = "USER@LOCALHOST", PasswordHash = hasher.HashPassword(null, "root"), EmailConfirmed = true }
            );
        }
    }
}