using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projectwebdev.Models;

namespace projectwebdev.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Stripboek> Stripboeken { get; set; }
    // public DbSet<Collectie> Collecties { get; set; }
    // public DbSet<Conditie> Condities { get; set; }
    // public DbSet<Producent> Producenten { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed basic roles and default admin
        new ApplicationDbInitializer(builder).Seed();

        //// Map entities to tables
        builder.Entity<Stripboek>().ToTable("Stripboeken");
        // builder.Entity<Collectie>().ToTable("Collecties");
        // builder.Entity<Conditie>().ToTable("Condities");
        // builder.Entity<Producent>().ToTable("Producenten");
        
        // Configure primary keys
        builder.Entity<Stripboek>().HasKey(s => s.Id).HasName("PK_Stripboeken");
        // builder.Entity<Collectie>().HasKey(c => c.CollectieID).HasName("PK_Collecties");
        // builder.Entity<Conditie>().HasKey(con => con.ISBN).HasName("PK_Condities");
        // builder.Entity<Producent>().HasKey(p => p.ProducentID).HasName("PK_Producenten");

        // Configure indexes
        // todo

        // Configure columns
        builder.Entity<Stripboek>().Property(s => s.Id).HasColumnType("int").UseMySqlIdentityColumn().ValueGeneratedOnAdd();
        builder.Entity<Stripboek>().Property(s => s.Titel).HasColumnType("varchar(255)");
        builder.Entity<Stripboek>().Property(s => s.Aantal_Blz).HasColumnType("int");
        builder.Entity<Stripboek>().Property(s => s.Isbn).HasColumnType("varchar(255)");
        builder.Entity<Stripboek>().Property(s => s.Jaar_Van_Uitgave).HasColumnType("int");
        builder.Entity<Stripboek>().Property(s => s.CoverImageUrl).HasColumnType("varchar(255)");

        //builder.Entity<Collectie>().Property(c => c.CollectieNaam).HasColumnType("string").IsRequired();
        //builder.Entity<Collectie>().Property(c => c.CollectieID).HasColumnType("int").IsRequired();

        //builder.Entity<Conditie>().Property(con => con.Gesealed).HasColumnType("bool").IsRequired();
        //builder.Entity<Conditie>().Property(con => con.Gesigneerd).HasColumnType("bool").IsRequired();
        //builder.Entity<Conditie>().Property(con => con.Kaft).HasColumnType("bool").IsRequired();
        //builder.Entity<Conditie>().Property(con => con.ConditieStripboek).HasColumnType("string").IsRequired();
        //builder.Entity<Conditie>().Property(con => con.ISBN).HasColumnType("int").IsRequired();

        //builder.Entity<Producent>().Property(p => p.Geboortedatum).HasColumnType("int").IsRequired();
        //builder.Entity<Producent>().Property(p => p.Naam).HasColumnType("string").IsRequired();
        //builder.Entity<Producent>().Property(p => p.Rol).HasColumnType("string").IsRequired();
        //builder.Entity<Producent>().Property(p => p.ProducentID).HasColumnType("int").IsRequired();

        // Configure relationships
        //todo zodra er meer tabellen zijn
    }
}