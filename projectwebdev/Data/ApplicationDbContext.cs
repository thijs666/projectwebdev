using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projectwebdev.Models;

namespace projectwebdev.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Stripboek> Stripboeken { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed basic roles and default admin
        new ApplicationDbInitializer(builder).Seed();

        // Map entities to tables
        builder.Entity<Stripboek>().ToTable("Stripboeken");

        // Configure primary keys
        builder.Entity<Stripboek>().HasKey(s => s.Isbn).HasName("PK_Stripboeken");

        // Configure indexes
        // todo

        // Configure columns
        builder.Entity<Stripboek>().Property(s => s.Titel).HasColumnType("int").IsRequired();
        builder.Entity<Stripboek>().Property(s => s.Aantal_Blz).HasColumnType("int").IsRequired();
        builder.Entity<Stripboek>().Property(s => s.Isbn).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
        builder.Entity<Stripboek>().Property(s => s.Jaar_Van_Uitgave).HasColumnType("int").IsRequired();

        // Configure relationships
        //todo zodra er meer tabellen zijn
    }
}