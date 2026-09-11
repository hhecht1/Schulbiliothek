
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchulbibliothekAP14.Models;

public class BuchController : Controller
{
    private readonly SchulbibliothekContext _context;

    public BuchController(SchulbibliothekContext context)
    {
        _context = context;
    }

    // GET: BUCHS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Buch.ToListAsync());
    }

    // GET: BUCHS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buch = await _context.Buch
            .FirstOrDefaultAsync(m => m.Id == id);
        if (buch == null)
        {
            return NotFound();
        }

        return View(buch);
    }

    // GET: BUCHS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BUCHS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Titel,Transaktionen")] Buch buch)
    {
        if (ModelState.IsValid)
        {
            _context.Add(buch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(buch);
    }

    // GET: BUCHS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buch = await _context.Buch.FindAsync(id);
        if (buch == null)
        {
            return NotFound();
        }
        return View(buch);
    }

    // POST: BUCHS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Titel,Transaktionen")] Buch buch)
    {
        if (id != buch.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(buch);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuchExists(buch.Id))
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
        return View(buch);
    }

    // GET: BUCHS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var buch = await _context.Buch
            .FirstOrDefaultAsync(m => m.Id == id);
        if (buch == null)
        {
            return NotFound();
        }

        return View(buch);
    }

    // POST: BUCHS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var buch = await _context.Buch.FindAsync(id);
        if (buch != null)
        {
            _context.Buch.Remove(buch);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BuchExists(int? id)
    {
        return _context.Buch.Any(e => e.Id == id);
    }
}