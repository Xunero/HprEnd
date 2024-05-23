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
    public class UzytkownikController : Controller
    {
        private readonly FilmyDbContext _context;

        public UzytkownikController(FilmyDbContext context)
        {
            _context = context;
        }

        // GET: Uzytkownik
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uzytkownicy.ToListAsync());
        }

        // GET: Uzytkownik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownicy
                .FirstOrDefaultAsync(m => m.ID_Uzytkownik == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        public IActionResult Login()
        {
            return View();
        }

        // GET: Uzytkownik/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Uzytkownik tbuzytkownik)
        {
            if (_context.Uzytkownicy.Any(x => x.Email == tbuzytkownik.Email && x.Haslo == tbuzytkownik.Haslo))
            {

                var user = _context.Uzytkownicy.FirstOrDefault(x => x.Email == tbuzytkownik.Email && x.Haslo == tbuzytkownik.Haslo);

                Response.Cookies.Append("ID", user.ID_Uzytkownik.ToString());
                if (user != null && user.ID_Typ >= 1 && user.ID_Typ <= 3)
                {
                    Response.Cookies.Append("UserRole", user.ID_Typ.ToString(), new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddMinutes(20),
                        HttpOnly = true
                    });
                }
                else
                {
                    Response.Cookies.Append("UserRole", "0", new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddMinutes(20),
                        HttpOnly = true
                    });
                }

                return View("logged");
            }
            else
            {
                return RedirectToAction("Failed");
            }
        }

        // GET: Uzytkownik/Create
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Uzytkownik tbuzytkownik)
        {
            if (ModelState.IsValid)
            {
                // Sprawdź, czy użytkownik o podanym adresie e-mail już istnieje w bazie danych
                if (!_context.Uzytkownicy.Any(x => x.Email == tbuzytkownik.Email && x.Login == tbuzytkownik.Login))
                {
                    tbuzytkownik.ID_Typ = 3;
                    // Dodaj nowego użytkownika do bazy danych
                    _context.Uzytkownicy.Add(tbuzytkownik);
                    await _context.SaveChangesAsync();
                    ViewBag.Created = "Konto stworzone";
                    return RedirectToAction("Login", "Uzytkownik");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Użytkownik o podanym adresie e-mail lub loginie już istnieje.");
                    return View(tbuzytkownik);
                }
            }
            return View(tbuzytkownik);
        }

        // GET: Uzytkownik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownicy.FindAsync(id);
            if (uzytkownik == null)
            {
                return NotFound();
            }
            return View(uzytkownik);
        }

        // POST: Uzytkownik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Uzytkownik,Email,Haslo,Login,ID_Typ")] Uzytkownik uzytkownik)
        {
            if (id != uzytkownik.ID_Uzytkownik)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uzytkownik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UzytkownikExists(uzytkownik.ID_Uzytkownik))
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
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uzytkownik = await _context.Uzytkownicy
                .FirstOrDefaultAsync(m => m.ID_Uzytkownik == id);
            if (uzytkownik == null)
            {
                return NotFound();
            }

            return View(uzytkownik);
        }

        // POST: Uzytkownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uzytkownik = await _context.Uzytkownicy.FindAsync(id);
            if (uzytkownik != null)
            {
                _context.Uzytkownicy.Remove(uzytkownik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UzytkownikExists(int id)
        {
            return _context.Uzytkownicy.Any(e => e.ID_Uzytkownik == id);
        }

        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("UserRole");

            return View("Logout");
        }

        public IActionResult Failed()
        {
            ViewBag.Failed = "Logowanie nieudane";
            return View("Login");
        }

    }
}
