using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIDEV.Models
{
    public class Childrengarden : User
    {
		public int id { get; set; }
		public String description { get; set; }
		public String nom { get; set; }


		public DateTime Creation_Date { get; set; }

		public String location { get; set; }
		public String photo { get; set; }
		public int phone_number { get; set; }
		public int price { get; set; }
	}
}
