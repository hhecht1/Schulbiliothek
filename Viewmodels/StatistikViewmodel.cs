namespace SchulbibliothekAP14.Viewmodels
{
    public class StatistikViewmodel
    {
        public decimal AnzahlAusleihen { get; set; }
        public decimal AnzahlRückgaben { get; set; }
        public DateOnly? DatumVon { get; set; }
        public DateOnly? DatumBis { get; set; }
        public int? PersonId { get; set; }
    }
}
