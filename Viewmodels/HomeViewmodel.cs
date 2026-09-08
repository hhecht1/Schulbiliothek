namespace SchulbibliothekAP14.Viewmodels
{
    public class HomeViewmodel
    {
        public string? Suche {  get; set; }
        public int? TransaktionTypId { get; set; }
        public int? PersonId { get; set; }
        public int? Anzahl { get; set; }
        public List<HomeListitemViewmodel> Items { get; set; } = new List<HomeListitemViewmodel>();
    }
}
