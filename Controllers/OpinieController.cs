using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HprEnd.Context;
using HprEnd.Models;

namespace HprEnd.Controllers
{
    public class OpinieController : Controller
    {
        private readonly FilmyDbContext _context;

        public OpinieController(FilmyDbContext context)
        {
            _context = context;
        }

        // GET: Opinie
        public async Task<IActionResult> Index()
        {
            var filmyDbContext = _context.Opinie.Include(o => o.Film).Include(o => o.Uzytkownik);
            return View(await filmyDbContext.ToListAsync());
        }

        // GET: Opinie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinie = await _context.Opinie
                .Include(o => o.Film)
                .Include(o => o.Uzytkownik)
                .FirstOrDefaultAsync(m => m.ID_Opinie == id);
            if (opinie == null)
            {
                return NotFound();
            }

            return View(opinie);
        }

        // GET: Opinie/Create
        public IActionResult Create()
        {
            ViewData["ID_Film"] = new SelectList(_context.Filmy, "ID_Film", "Opis");
            ViewData["ID_Uzytkownik"] = new SelectList(_context.Uzytkownicy, "ID_Uzytkownik", "Email");
            return View();
        }

        // POST: Opinie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Opinie,Opis,ID_Uzytkownik,ID_Film")] Opinie opinie)
        {
                ViewData["ID_Film"] = new SelectList(_context.Filmy, "ID_Film", "Opis", opinie.ID_Film);
                _context.Add(opinie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Opinie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinie = await _context.Opinie.FindAsync(id);
            if (opinie == null)
            {
                return NotFound();
            }
            ViewData["ID_Film"] = new SelectList(_context.Filmy, "ID_Film", "Opis", opinie.ID_Film);
            return View(opinie);
        }

        // POST: Opinie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Opinie,Opis,ID_Uzytkownik,ID_Film")] Opinie opinie, Uzytkownik tbuzytkownik)
        {
            if (id != opinie.ID_Opinie)
            {
                return NotFound();
            }
                
            
            _context.Update(opinie);
            await _context.SaveChangesAsync();
                
            ViewData["ID_Film"] = new SelectList(_context.Filmy, "ID_Film", "Opis", opinie.ID_Film);

            return RedirectToAction(nameof(Index));
        }

        // GET: Opinie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinie = await _context.Opinie
                .Include(o => o.Film)
                .Include(o => o.Uzytkownik)
                .FirstOrDefaultAsync(m => m.ID_Opinie == id);
            if (opinie == null)
            {
                return NotFound();
            }

            return View(opinie);
        }

        // POST: Opinie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opinie = await _context.Opinie.FindAsync(id);
            if (opinie != null)
            {
                _context.Opinie.Remove(opinie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpinieExists(int id)
        {
            return _context.Opinie.Any(e => e.ID_Opinie == id);
        }
    }
}
