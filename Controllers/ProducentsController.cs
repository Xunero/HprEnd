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
    public class ProducentsController : Controller
    {
        private readonly FilmyDbContext _context;

        public ProducentsController(FilmyDbContext context)
        {
            _context = context;
        }

        // GET: Producents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producenci.ToListAsync());
        }

        // GET: Producents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producent = await _context.Producenci
                .FirstOrDefaultAsync(m => m.ID_Producent == id);
            if (producent == null)
            {
                return NotFound();
            }

            return View(producent);
        }

        // GET: Producents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Producent,Nazwa,Siedziba")] Producent producent)
        {
                _context.Add(producent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Producents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producent = await _context.Producenci.FindAsync(id);
            if (producent == null)
            {
                return NotFound();
            }
            return View(producent);
        }

        // POST: Producents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Producent,Nazwa,Siedziba")] Producent producent)
        {
            if (id != producent.ID_Producent)
            {
                return NotFound();
            }

            
            _context.Update(producent);
            await _context.SaveChangesAsync();
                
                    
            return View(producent);
        }

        // GET: Producents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producent = await _context.Producenci
                .FirstOrDefaultAsync(m => m.ID_Producent == id);
            if (producent == null)
            {
                return NotFound();
            }

            return View(producent);
        }

        // POST: Producents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producent = await _context.Producenci.FindAsync(id);
            if (producent != null)
            {
                _context.Producenci.Remove(producent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProducentExists(int id)
        {
            return _context.Producenci.Any(e => e.ID_Producent == id);
        }
    }
}
