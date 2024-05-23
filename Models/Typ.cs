using System.ComponentModel.DataAnnotations;

namespace HprEnd.Models
{
    public class Typ
    {
        [Key]
        public int ID_Typ { get; set; }

        [Required]
        [StringLength(50)]
        public required string Typ_uzytkownika { get; set; }

        public required List<Uzytkownik> Uzytkownicy { get; set; }
    }
}
