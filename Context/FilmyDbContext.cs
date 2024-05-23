using HprEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace HprEnd.Context
{
    public class FilmyDbContext : DbContext
    {
        public FilmyDbContext(DbContextOptions<FilmyDbContext> options) : base(options)
        {
        }

        public DbSet<Film> Filmy { get; set; }
        public DbSet<Producent> Producenci { get; set; }
        public DbSet<Typ> Typy { get; set; }
        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<FilmOcena> Oceny { get; set; }
        public DbSet<Film_Kategoria> Kategorie { get; set; }
        public DbSet<Opinie> Opinie { get; set; } 

    }
}
