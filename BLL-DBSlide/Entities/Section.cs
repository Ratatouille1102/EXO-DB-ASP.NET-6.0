using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_DBSlide.Entities
{
    public class Section
    {
        public int Section_Id { get; set; }
        public string Section_Name { get; set; }
        //public int? Delegate_Id { get; set; }
        public Student? Delegate { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
