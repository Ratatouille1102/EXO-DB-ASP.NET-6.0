using ASP_DBSlide.Models.Student;
using System.ComponentModel;

namespace ASP_DBSlide.Models.Group
{
    public class GroupDetailsViewModel
    {
        [DisplayName("Nom du groupe")]
        public string Name { get; set; }
        [DisplayName("Liste des étudiants")]
        public IEnumerable<StudentListItem> Students { get; set; }
    }
}
