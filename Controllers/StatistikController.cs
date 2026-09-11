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

            var ausleihenQuery = _context.Transaktion
                .Where(t => t.TransaktionTypId == 1).AsQueryable();
            var rückgabenQuery = _context.Transaktion
                .Where(t => t.TransaktionTypId == 2).AsQueryable();

            if (viewmodel.PersonId.HasValue)
            {
                ausleihenQuery = ausleihenQuery.Where(x => x.PersonId == viewmodel.PersonId);
                rückgabenQuery = rückgabenQuery.Where(x => x.PersonId == viewmodel.PersonId);
            }
            if (viewmodel.DatumVon.HasValue)
            {
                ausleihenQuery = ausleihenQuery.Where(x => DateOnly
                .FromDateTime(x.Datum) >= viewmodel.DatumVon);

                rückgabenQuery = rückgabenQuery.Where(x => DateOnly
                .FromDateTime(x.Datum) >= viewmodel.DatumVon);
            }


            var anzahlAusleihen = await ausleihenQuery.CountAsync();
            var anzahlRückgaben = await rückgabenQuery.CountAsync();
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