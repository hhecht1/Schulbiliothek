using System.ComponentModel.DataAnnotations.Schema;

namespace SchulbibliothekAP14.Models
{
    [NotMapped]
    public class TopBuchDto
    {
        public int BuchId { get; set; }
        public string Buch { get; set; } = string.Empty;
        public int Anzahl { get; set; }
        public string Personen { get; set; } = string.Empty;
    }
}