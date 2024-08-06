using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_DBSlide.Models.Student
{
    public class StudentListItem
    {
        [ScaffoldColumn(false)]
        [DisplayName("Identifiant")]
        public int Student_Id { get; set; }
        [DisplayName("Prénom")]
        public string First_Name { get; set; }
        [DisplayName("Nom de famille")]
        public string Last_Name { get; set; }
    }
}
