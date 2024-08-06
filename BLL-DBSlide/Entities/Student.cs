using System;
using System.Collections.Generic;
using System.Text;

namespace BLL_DBSlide.Entities
{
    public class Student
    {
        public int Student_id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Birth_date { get; set; }
        public string Login {
            get {
                if(Last_name.Length >= 7)
                    return $"{First_name.ToLower()[0]}{Last_name.ToLower().Substring(0, 7)}";
                return $"{First_name.ToLower()[0]}{Last_name.ToLower()}";
            }
        }
        //public int Section_id { get; set; }
        public Section Section { get; set; }
        private int? _year_result;
        public int? Year_result {
            get { return _year_result; }
            set {
                if (!(value is null) && (value < 0 || value > 20)) throw new ArgumentOutOfRangeException(nameof(value), "Le résultat scolaire doit être entre 0 et 20.");
                    _year_result = value;    
            } 
        }
        public string Course_id { get; set; }
    }
}
