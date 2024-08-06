using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_DBSlide.Entities
{
    public class Student
    {
        public int Student_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Birth_date { get; set; }
        public string Login { get; set; }
        public int Section_id { get; set; }
        public int? Year_result { get; set; }
        public string Course_id { get; set; }
    }
}
