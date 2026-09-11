namespace SchulbibliothekAP14.Models
{
    public class PersonenTyp
    {
        public int Id { get; set; }
        public string? Beschreibung { get; set; }

        public List<Person> Personen { get; set; } = new List<Person>();
    }
}
