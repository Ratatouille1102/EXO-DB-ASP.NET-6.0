using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_DBSlide.Models.Section
{
    public class SectionListItem
    {
        [ScaffoldColumn(false)]
        [DisplayName("Identifiant")]
        public int Section_Id { get; set; }
        [DisplayName("Nom")]
        public string Section_Name { get; set; }
    }
}
