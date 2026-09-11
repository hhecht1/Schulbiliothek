using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace SchulbibliothekAP14.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }
        public byte[]? Bild { get; set; }
        public bool IstAktiv { get; set; }
        public int PersonenTypId { get; set; }

        public PersonenTyp? PersonenTyp { get; set; }
        public List<Transaktion> Transaktionen { get; set; } = new List<Transaktion>();

        [NotMapped]
        public IFormFile? FormFile { get; set; }
    }
}
