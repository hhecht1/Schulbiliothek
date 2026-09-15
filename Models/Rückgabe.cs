namespace SchulbibliothekAP14.Models
{
    public class Rückgabe
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string? Bemerkung { get; set; }
        public int BuchId { get; set; }
        public int TransaktionTypId { get; set; }
        public int PersonId { get; set; }
    }
}