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
    public class FilmsController : Controller
    {
        private readonly FilmyDbContext _context;

        public FilmsController(FilmyDbContext context)
        {
            _context = context;
        }

        // GET: Films
        public async Task<IActionResult> Index(string searchString)
        {
            IQueryable<Film> filmyDbContext = _context.Filmy
                                                        .Include(f => f.FilmOcena)
                                                        .Include(f => f.Film_Kategoria)
                                                        .Include(f => f.Producent);

            if (!String.IsNullOrEmpty(searchString))
            {
                filmyDbContext = filmyDbContext.Where(f => f.Tytul.Contains(searchString));
            }

            return View(await filmyDbContext.ToListAsync());
        }
        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Filmy
                .Include(f => f.FilmOcena)
                .Include(f => f.Film_Kategoria)
                .Include(f => f.Producent)
                .FirstOrDefaultAsync(m => m.ID_Film == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            ViewData["ID_FilmOcena"] = new SelectList(_context.Oceny, "ID_FilmOcena", "ID_FilmOcena");
            ViewData["ID_Kategoria"] = new SelectList(_context.Kategorie, "ID_Kategoria", "Nazwa");
            ViewData["ID_Producent"] = new SelectList(_context.Producenci, "ID_Producent", "Nazwa");
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Film,Tytul,Data_wydania,Dlugosc,Opis,ID_Producent,ID_Kategoria,ID_FilmOcena")] Film film)
        {
 
            _context.Add(film);
            await _context.SaveChangesAsync();
            ViewData["ID_FilmOcena"] = new SelectList(_context.Oceny, "ID_FilmOcena", "ID_FilmOcena", film.ID_FilmOcena);
            ViewData["ID_Kategoria"] = new SelectList(_context.Kategorie, "ID_Kategoria", "Nazwa", film.ID_Kategoria);
            ViewData["ID_Producent"] = new SelectList(_context.Producenci, "ID_Producent", "Nazwa", film.ID_Producent);
            return RedirectToAction(nameof(Index));
            
            
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Filmy.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["ID_FilmOcena"] = new SelectList(_context.Oceny, "ID_FilmOcena", "ID_FilmOcena", film.ID_FilmOcena);
            ViewData["ID_Kategoria"] = new SelectList(_context.Kategorie, "ID_Kategoria", "Nazwa", film.ID_Kategoria);
            ViewData["ID_Producent"] = new SelectList(_context.Producenci, "ID_Producent", "Nazwa", film.ID_Producent);
            return RedirectToAction(nameof(Index));
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Film,Tytul,Data_wydania,Dlugosc,Opis,ID_Producent,ID_Kategoria,ID_FilmOcena")] Film film)
        {
            if (id != film.ID_Film)
            {
                return NotFound();
            }

            _context.Update(film);
            await _context.SaveChangesAsync();

            ViewData["ID_FilmOcena"] = new SelectList(_context.Oceny, "ID_FilmOcena", "ID_FilmOcena", film.ID_FilmOcena);
            ViewData["ID_Kategoria"] = new SelectList(_context.Kategorie, "ID_Kategoria", "Nazwa", film.ID_Kategoria);
            ViewData["ID_Producent"] = new SelectList(_context.Producenci, "ID_Producent", "Nazwa", film.ID_Producent);
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Filmy
                .Include(f => f.FilmOcena)
                .Include(f => f.Film_Kategoria)
                .Include(f => f.Producent)
                .FirstOrDefaultAsync(m => m.ID_Film == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Filmy.FindAsync(id);
            if (film != null)
            {
                _context.Filmy.Remove(film);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Filmy.Any(e => e.ID_Film == id);
        }
    }
}
