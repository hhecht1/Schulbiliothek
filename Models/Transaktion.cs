using System.ComponentModel.DataAnnotations;

namespace SchulbibliothekAP14.Models
{
    public class Transaktion
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }

        [MaxLength(50)]
        public string? Bemerkung { get; set; }
        public int BuchId { get; set; }
        public int TransaktionTypId { get; set; }
        public int PersonId { get; set; }

        public Buch? Buch { get; set; }
        public Person? Person { get; set; }
        public TransaktionTyp? TransaktionTyp { get; set; }
    }
}
