using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_DBSlide.Entities
{
    public class Section
    {
        public int Section_id { get; set; }
        public string Section_name { get; set; }
        public int? Delegate_id { get; set; }
    }
}
