using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HprEnd.Models
{
    public class Uzytkownik
    {
        [Key]
        public int ID_Uzytkownik { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public required string Email { get; set; }

        [Required]
        [StringLength(255)]
        public required string Haslo { get; set; }

        [Required]
        [StringLength(50)]
        public required string Login { get; set; }

        [ForeignKey("Typ")]
        public int ID_Typ { get; set; }
    }
}
