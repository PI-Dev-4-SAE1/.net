using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Comments : AuditModel
    {
       
        public int id { get; set; }
        public string text { get; set; }
    }
}