using System.ComponentModel;

namespace ASP_DBSlide.Models.Student
{
    public class StudentDeleteForm
    {
        [DisplayName("Prénom")]
        public string First_Name { get; set; }
        [DisplayName("Nom de famille")]
        public string Last_Name { get; set; }
        [DisplayName("Section")]
        public int Section_Id { get; set; }
    }
}
