using Microsoft.AspNetCore.Mvc;
using SchulbibliothekAP14.Models;
using SchulbibliothekAP14.Viewmodels;
using System.Diagnostics;

namespace SchulbibliothekAP14.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchulbibliothekContext _context;

        public HomeController(ILogger<HomeController> logger, SchulbibliothekContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(HomeViewmodel viewmodel)
        {
            SetViewData();
            var query = _context.Transaktion.AsQueryable();

            if (!string.IsNullOrEmpty(viewmodel.Suche))
                query = query.Where(t => t.Bemerkung.Contains(viewmodel.Suche));

            if (viewmodel.TransaktionTypId.HasValue)
                query = query.Where(t => t.TransaktionTypId == viewmodel.TransaktionTypId.Value);

            if (viewmodel.PersonId.HasValue)
                query = query.Where(t => t.PersonId == viewmodel.PersonId.Value);

            if (viewmodel.Anzahl.HasValue)
                query = query.Take(viewmodel.Anzahl.Value);

            var list = query.Select(li => new HomeListitemViewmodel
            {
                Bemerkung = li.Bemerkung,
                Titel = li.Buch.Titel,
                Datum = li.Datum,
                Person = $"{li.Person.Vorname} {li.Person.Nachname}",
                PersonId = li.PersonId,
                TransaktionTyp = li.TransaktionTyp.Beschreibung
            }).OrderByDescending(li => li.Datum)
            .ToList();

            viewmodel.Items = list;

            return View(viewmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void SetViewData()
        {
            var mitglieder = _context.Person.ToList();
            ViewData["Personen"] = mitglieder;
        }
    }
}