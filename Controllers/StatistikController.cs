using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchulbibliothekAP14.Viewmodels;
using ScottPlot;

namespace SchulbibliothekAP14.Controllers
{
    public class StatistikController : Controller
    {
        private readonly SchulbibliothekContext _context;

        public StatistikController(SchulbibliothekContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(StatistikViewmodel viewmodel)
        {
            SetMitgliedId(viewmodel.PersonId);
            SetMitgliedId(viewmodel.PersonId);
            var ausleihenquery = _context.Transaktion
                .Where(t => t.TransaktionTypId == 1).AsQueryable();
            var rückgabenquery = _context.Transaktion
                .Where(t => t.TransaktionTypId == 2).AsQueryable();



            if (viewmodel.PersonId.HasValue)
            {
                ausleihenquery = ausleihenquery.Where(t => t.PersonId == viewmodel.PersonId.Value);
                rückgabenquery = rückgabenquery.Where(t => t.PersonId == viewmodel.PersonId.Value);
            }
            if (viewmodel.DatumVon.HasValue)
            {
                ausleihenquery = ausleihenquery.Where(x => DateOnly.FromDateTime(x.Datum) >= viewmodel.DatumVon);
                rückgabenquery = rückgabenquery.Where(x => DateOnly.FromDateTime(x.Datum) >= viewmodel.DatumVon);
            }
            if (viewmodel.DatumBis.HasValue)
            {
                ausleihenquery = ausleihenquery.Where(y => DateOnly.FromDateTime(y.Datum) <= viewmodel.DatumBis);
                rückgabenquery = rückgabenquery.Where(y => DateOnly.FromDateTime(y.Datum) <= viewmodel.DatumBis);
            }

            var anzahlAusleihen = await ausleihenquery.CountAsync();
            var anzahlRückgaben = await rückgabenquery.CountAsync();

            viewmodel.AnzahlAusleihen = anzahlAusleihen;
            viewmodel.AnzahlRückgaben = anzahlRückgaben;

            return View(viewmodel);
        }


        public async Task<IActionResult> FuenfHoechsteAusleihen(StatistikViewmodel viewmodel)
        {


            return File(new byte[] { 1, 2, 3 }, "image/png");
        }


        private void SetMitgliedId(int? mitgliedId)
        {
            var mitglieder = _context.Person.ToList();
            ViewData["Personen"] = mitglieder;
        }

    }
}