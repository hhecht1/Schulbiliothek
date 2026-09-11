using System.Linq.Expressions;

namespace SchulbibliothekAP14.Models
{
    public class Buch
    {
        public int Id { get; set; }
        public string? Titel { get; set; }

        public List<Transaktion> Transaktionen { get; set; } = new List<Transaktion>();
    }
}
