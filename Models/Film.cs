using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HprEnd.Models
{
    public class Film
    {
        [Key]
        public int ID_Film { get; set; }

        [Required]
        [StringLength(70)]
        public required string Tytul { get; set; }

        [Required]
        public DateTime Data_wydania { get; set; }

        [Required]
        public int Dlugosc { get; set; }

        [Required]
        public string Opis { get; set; }

        [ForeignKey("Producent")]
        public int ID_Producent { get; set; }
        public required Producent Producent { get; set; }

        [ForeignKey("Film_Kategoria")]
        public int ID_Kategoria { get; set; }
        public required Film_Kategoria Film_Kategoria { get; set; }

        [ForeignKey("FilmOcena")]
        public int ID_FilmOcena { get; set; }

        public required FilmOcena FilmOcena { get; set; }
    }
}