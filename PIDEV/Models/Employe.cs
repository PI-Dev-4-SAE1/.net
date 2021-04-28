using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIDEV.Models
{
    public class Employe
    {
		public int id { get; set; }
		public String first_name { get; set; }
		public String last_name { get; set; }


		public String email { get; set; }

		public String password { get; set; }
		public String job { get; set; }
		public String disponability { get; set; }
		
	}
}
