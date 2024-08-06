using ASP_DBSlide.Models.Section;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_DBSlide.Models.Student
{
    public class StudentCreateForm
    {
        [DisplayName("Prénom : ")]
        [Required(ErrorMessage ="Est obligatoire.")]
        [MinLength(3,ErrorMessage ="Nécessite minimum de 3 caractères.")]
        [MaxLength(50,ErrorMessage = "Ne peut excéder 50 caractères.")]
        public string First_Name { get; set; }
        [DisplayName("Nom de famille : ")]
        [Required(ErrorMessage ="Est obligatoire.")]
        [MinLength(3, ErrorMessage = "Nécessite minimum de 3 caractères.")]
        [MaxLength(50, ErrorMessage = "Ne peut excéder 50 caractères.")]
        public string Last_Name { get; set; }
        [DisplayName("Date de naissance : ")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Est obligatoire.")]
        public DateTime Birth_Date { get; set; }
        [DisplayName("Section souhaitée : ")]
        [Required(ErrorMessage ="Est obligatoire.")]
        public int Section_id { get; set; }
    }
}
