using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_DBSlide.Models.Section
{
    public class SectionEditForm
    {
        [Required(ErrorMessage = "Est obligatoire.")]
        [MinLength(3, ErrorMessage = "Nécessite au minimum 3 caractères.")]
        [MaxLength(50, ErrorMessage = "Ne peut excéder 50 caractères.")]
        [DisplayName("Nom : ")]
        public string Section_Name { get; set; }
        [DisplayName("Délégué : ")]
        public int? Delegate_Id { get; set; }
    }
}
