using Microsoft.EntityFrameworkCore;

public class SchulbibliothekContext(DbContextOptions<SchulbibliothekContext> options) : DbContext(options)
{
    public DbSet<SchulbibliothekAP14.Models.Person> Person { get; set; } = default!;
    public DbSet<SchulbibliothekAP14.Models.Buch> Buch { get; set; } = default!;
    public DbSet<SchulbibliothekAP14.Models.Transaktion> Transaktion { get; set; } = default!;
    public DbSet<SchulbibliothekAP14.Models.PersonenTyp> PersonenTyp { get; set; } = default!;
    public DbSet<SchulbibliothekAP14.Models.TransaktionTyp> TransaktionTyp { get; set; } = default!;
}
