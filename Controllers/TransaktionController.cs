
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchulbibliothekAP14.Models;

public class TransaktionController : Controller
{
    private readonly SchulbibliothekContext _context;

    public TransaktionController(SchulbibliothekContext context)
    {
        _context = context;
    }

    // GET: TRANSAKTIONS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Transaktion.ToListAsync());
    }

    // GET: TRANSAKTIONS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var transaktion = await _context.Transaktion
            .FirstOrDefaultAsync(m => m.Id == id);
        if (transaktion == null)
        {
            return NotFound();
        }

        return View(transaktion);
    }

    // GET: TRANSAKTIONS/Create
    public IActionResult Create()
    {
        SetViewData();
        return View();
    }

    // POST: TRANSAKTIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Datum,Bemerkung,BuchId,TransaktionTypId,Buch,PersonId,TransaktionTyp")] Transaktion transaktion)
    {
        SetViewData();
        if (ModelState.IsValid)
        {
            if (transaktion.Datum > DateTime.Now)
            {
                ModelState.AddModelError(nameof(transaktion.Datum), "Das Datum darf nicht in der Zukunft liegen");
                return View(transaktion);
            }

            var person = await _context.Person.FindAsync(transaktion.PersonId);

            if (person == null || !person.IstAktiv)
            {
                ModelState.AddModelError(nameof(person.Id), "Diese Person ist nicht mehr vorhanden oder inaktiv");
            }

            _context.Add(transaktion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(transaktion);
    }

    // GET: TRANSAKTIONS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        SetViewData();
        if (id == null)
        {
            return NotFound();
        }

        var transaktion = await _context.Transaktion.FindAsync(id);
        if (transaktion == null)
        {
            return NotFound();
        }
        return View(transaktion);
    }

    // POST: TRANSAKTIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Datum,Bemerkung,BuchId,TransaktionTypId,Buch,PersonId,TransaktionTyp")] Transaktion transaktion)
    {
        SetViewData();
        if (id != transaktion.Id)
        {
            return NotFound();
        }

        if (transaktion.Datum > DateTime.Now)
        {
            ModelState.AddModelError(nameof(transaktion.Datum), "Das Datum darf nicht in der Zukunft liegen");
            return View(transaktion);
        }

        var person = await _context.Person.FindAsync(transaktion.PersonId);
        if (person == null || !person.IstAktiv)
        {
            ModelState.AddModelError(nameof(person.Id), "Diese Person ist nicht mehr vorhanden oder inaktiv");
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(transaktion);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaktionExists(transaktion.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(transaktion);
    }

    // GET: TRANSAKTIONS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var transaktion = await _context.Transaktion
            .FirstOrDefaultAsync(m => m.Id == id);
        if (transaktion == null)
        {
            return NotFound();
        }

        return View(transaktion);
    }

    // POST: TRANSAKTIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var transaktion = await _context.Transaktion.FindAsync(id);
        if (transaktion != null)
        {
            _context.Transaktion.Remove(transaktion);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TransaktionExists(int? id)
    {
        return _context.Transaktion.Any(e => e.Id == id);
    }

    private void SetViewData()
    {
        var personen = _context.Person.Where(p => p.IstAktiv).ToList();
        ViewData["Personen"] = personen;
        var transaktiontypen = _context.TransaktionTyp.ToList();
        ViewData["Transaktiontypen"] = transaktiontypen;
        var buecher = _context.Buch.ToList();
        ViewData["Buecher"] = buecher;
    }
}