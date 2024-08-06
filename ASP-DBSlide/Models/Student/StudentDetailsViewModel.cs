using ASP_DBSlide.Models.Section;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_DBSlide.Models.Student
{
    public class StudentDetailsViewModel
    {
        [DisplayName("Identifiant")]
        public int Student_Id { get; set; }
        [DisplayName("Prénom")]
        public string First_Name { get; set; }
        [DisplayName("Nom de famille")]
        public string Last_Name { get; set; }
        [DisplayName("Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime Birth_Date { get; set; }
        [DisplayName("Login")]
        public string Login { get; set; }

        public SectionDetailsViewModel SectionDetails { get; set; }
        
        [DisplayName("Résultat annuel")]
        public int? Year_Result { get; set; }
        [DisplayName("Cours suivi")]
        public string Course_Id { get; set; }
    }
}
