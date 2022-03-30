using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projectwebdev.Models;

namespace projectwebdev.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Stripboek> Stripboeken { get; set; }
    public DbSet<Collectie> Collecties { get; set; }
    public DbSet<Conditie> Condities { get; set; }
    public DbSet<Producent> Producenten { get; set; }
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
        builder.Entity<Collectie>().ToTable("Collecties");
        builder.Entity<Conditie>().ToTable("Condities");
        builder.Entity<Producent>().ToTable("Producenten");
        
        // Configure primary keys
        builder.Entity<Stripboek>().HasKey(s => s.Id).HasName("PK_Stripboeken");
        builder.Entity<Collectie>().HasKey(c => c.CollectieID).HasName("PK_Collecties");
        builder.Entity<Conditie>().HasKey(con => con.ISBN).HasName("PK_Condities");
        builder.Entity<Producent>().HasKey(p => p.ProducentID).HasName("PK_Producenten");

        // Configure indexes
        // todo

        // Configure columns
        builder.Entity<Stripboek>().Property(s => s.Id).HasColumnType("int").UseMySqlIdentityColumn().ValueGeneratedOnAdd();
        builder.Entity<Stripboek>().Property(s => s.Titel).HasColumnType("varchar(255)");
        builder.Entity<Stripboek>().Property(s => s.Aantal_Blz).HasColumnType("int");
        builder.Entity<Stripboek>().Property(s => s.Schrijver).HasColumnType("varchar(255)");
        builder.Entity<Stripboek>().Property(s => s.Tekenaar).HasColumnType("varchar(255)");
        builder.Entity<Stripboek>().Property(s => s.Isbn).HasColumnType("varchar(255)");
        builder.Entity<Stripboek>().Property(s => s.Verschijningsdatum).HasColumnType("date");
        builder.Entity<Stripboek>().Property(s => s.Uitgever).HasColumnType("varchar(255)");
        builder.Entity<Stripboek>().Property(s => s.CoverImageUrl).HasColumnType("varchar(255)");

        builder.Entity<Collectie>().Property(c => c.CollectieNaam).HasColumnType("varchar(255)");
        builder.Entity<Collectie>().Property(c => c.CollectieID).HasColumnType("int").UseMySqlIdentityColumn().ValueGeneratedOnAdd();

        builder.Entity<Conditie>().Property(con => con.Gesealed).HasColumnType("tinyint");
        builder.Entity<Conditie>().Property(con => con.Gesigneerd).HasColumnType("tinyint");
        builder.Entity<Conditie>().Property(con => con.Kaft).HasColumnType("tinyint");
        builder.Entity<Conditie>().Property(con => con.ConditieStripboek).HasColumnType("varchar(255)");
        builder.Entity<Conditie>().Property(con => con.ISBN).HasColumnType("int").UseMySqlIdentityColumn();

        builder.Entity<Producent>().Property(p => p.Geboortedatum).HasColumnType("int");
        builder.Entity<Producent>().Property(p => p.Naam).HasColumnType("varchar(255)");
        builder.Entity<Producent>().Property(p => p.Rol).HasColumnType("varchar(255)");
        builder.Entity<Producent>().Property(p => p.ProducentID).HasColumnType("int").UseMySqlIdentityColumn().ValueGeneratedOnAdd();

        // Configure relationships
        //todo zodra er meer tabellen zijn
    }
}