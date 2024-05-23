using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HprEnd.Models
{
    [PrimaryKey(nameof(ID_FilmOcena))]
    public class FilmOcena
    {
        public int ID_FilmOcena { get; set; }
        [Required]
        public int Ocena { get; set; }

        public required List<Film> Filmy { get; set; }
    }
}
