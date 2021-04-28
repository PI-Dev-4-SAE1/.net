using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIDEV.Models
{
    public class Consulatation
    {
        public int id { get; set; }
        public string child_name { get; set; }
        public List<object> name_doctor { get; set; }
        public string namedoctor { get; set; }
        public string consultation_date { get; set; }
        public string consultation_time { get; set; }
        public string description { get; set; }
    }
}
