using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HprEnd.Models
{
    public class Opinie
    {
        [Key]
        public int ID_Opinie { get; set; }
        [Required]
        public string Opis { get; set; }

        [ForeignKey("Uzytkownik")]
        public int ID_Uzytkownik { get; set; }
        public required Uzytkownik Uzytkownik { get; set; }

        [ForeignKey("Film")]
        public int ID_Film { get; set; }

        public Film Film { get; set; }
    }
}
