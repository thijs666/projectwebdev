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
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
            );
    }
}
