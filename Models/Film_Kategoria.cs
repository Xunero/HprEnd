using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HprEnd.Models
{

    public class Film_Kategoria
    {
        [Key]
        public int ID_Kategoria { get; set; }
        [Required]
        public string Nazwa { get; set; }

        public ICollection<Film> Filmy { get; set; }

    }
}
