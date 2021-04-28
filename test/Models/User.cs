using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
   
    public class User
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}