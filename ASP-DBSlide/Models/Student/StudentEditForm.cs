using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_DBSlide.Models.Student
{
    public class StudentEditForm
    {

        [Required(ErrorMessage = "Est obligatoire.")]
        [DisplayName("Section :")]
        public int Section_Id { get; set; }
        [DisplayName("Résultat annuel :")]
        [Required(ErrorMessage = "Est obligatoire.")]
        [Range(0,20, ErrorMessage ="Le résultat annuel doit être compris entre 0 et 20.")]
        public int? Year_Result { get; set; }
        [DisplayName("Cours suivi :")]
        [Required(ErrorMessage = "Est obligatoire.")]
        public string Course_Id { get; set; }
    }
}
