using ASP_DBSlide.Models.Student;
using System.ComponentModel;

namespace ASP_DBSlide.Models.Section
{
    public class SectionDetailsViewModel
    {
        [DisplayName("Identifiant")]
        public int Section_Id { get; set; }
        [DisplayName("Nom")]
        public string Section_Name { get; set; }
        [DisplayName("Délégué")]
        public StudentListItem Delegate { get; set; }
        [DisplayName("Inscrits")]
        public IEnumerable<StudentListItem> Students { get; set; }
    }
}
