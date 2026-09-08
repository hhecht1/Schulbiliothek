namespace SchulbibliothekAP14.Models
{
    public class TransaktionTyp
    {
        public int Id { get; set; }
        public string Beschreibung { get; set; }

        public List<Transaktion> Transaktionen { get; set; } = new List<Transaktion>();
    }
}
