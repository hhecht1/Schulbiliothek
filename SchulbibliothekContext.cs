using Microsoft.EntityFrameworkCore;
using SchulbibliothekAP14.Models;

public class SchulbibliothekContext(DbContextOptions<SchulbibliothekContext> options) : DbContext(options)
{
    public DbSet<SchulbibliothekAP14.Models.Person> Person { get; set; } = default!;
    public DbSet<SchulbibliothekAP14.Models.Buch> Buch { get; set; } = default!;
    public DbSet<SchulbibliothekAP14.Models.Transaktion> Transaktion { get; set; } = default!;
    public DbSet<SchulbibliothekAP14.Models.PersonenTyp> PersonenTyp { get; set; } = default!;
    public DbSet<SchulbibliothekAP14.Models.TransaktionTyp> TransaktionTyp { get; set; } = default!;
    public DbSet<SchulbibliothekAP14.Models.Ausleihe> Ausleihen { get; set; } = default!;
    public DbSet<SchulbibliothekAP14.Models.Rückgabe> Rückgaben { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ausleihe>().HasNoKey().ToView("Ausleihen", "dbo");
        modelBuilder.Entity<Rückgabe>().HasNoKey().ToView("Rückgaben", "dbo");
    }
}