using System.ComponentModel.DataAnnotations;

namespace HprEnd.Models
{
    public class Producent
    {
        [Key]
        public int ID_Producent { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nazwa { get; set; }

        [Required]
        [StringLength(100)]
        public required string Siedziba { get; set; }

        public required List<Film> Filmy { get; set; }
    }
}
