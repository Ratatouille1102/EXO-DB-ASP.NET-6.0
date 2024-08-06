using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_DBSlide.Models.Group
{
    public class GroupCreateForm
    {
        [Required(ErrorMessage="Est obligatoire.")]
        [DisplayName("Nom du groupe : ")]
        public string Name { get; set; }
    }
}
