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
    public class KategoriaController : Controller
    {
        private readonly FilmyDbContext _context;

        public KategoriaController(FilmyDbContext context)
        {
            _context = context;
        }

        // GET: Kategoria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kategorie.ToListAsync());
        }

        // GET: Kategoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film_Kategoria = await _context.Kategorie
                .FirstOrDefaultAsync(m => m.ID_Kategoria == id);
            if (film_Kategoria == null)
            {
                return NotFound();
            }

            return View(film_Kategoria);
        }

        // GET: Kategoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Kategoria,Nazwa")] Film_Kategoria film_Kategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film_Kategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film_Kategoria);
        }

        // GET: Kategoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film_Kategoria = await _context.Kategorie.FindAsync(id);
            if (film_Kategoria == null)
            {
                return NotFound();
            }
            return View(film_Kategoria);
        }

        // POST: Kategoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Kategoria,Nazwa")] Film_Kategoria film_Kategoria)
        {
            if (id != film_Kategoria.ID_Kategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film_Kategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Film_KategoriaExists(film_Kategoria.ID_Kategoria))
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
            return View(film_Kategoria);
        }

        // GET: Kategoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film_Kategoria = await _context.Kategorie
                .FirstOrDefaultAsync(m => m.ID_Kategoria == id);
            if (film_Kategoria == null)
            {
                return NotFound();
            }

            return View(film_Kategoria);
        }

        // POST: Kategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film_Kategoria = await _context.Kategorie.FindAsync(id);
            if (film_Kategoria != null)
            {
                _context.Kategorie.Remove(film_Kategoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Film_KategoriaExists(int id)
        {
            return _context.Kategorie.Any(e => e.ID_Kategoria == id);
        }
    }
}
