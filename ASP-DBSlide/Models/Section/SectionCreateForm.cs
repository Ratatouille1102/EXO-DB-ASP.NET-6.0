using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_DBSlide.Models.Section
{
    public class SectionCreateForm
    {
        [Required(ErrorMessage = "Est obligatoire.")]
        [DisplayName("Identifiant : ")]
        public int Section_Id { get; set; }
        [Required(ErrorMessage = "Est obligatoire.")]
        [MinLength(3, ErrorMessage = "Nécessite au minimum 3 caractères.")]
        [MaxLength(50, ErrorMessage = "Ne peut excéder 50 caractères.")]
        [DisplayName("Nom : ")]
        public string Section_Name { get; set; }
    }
}
