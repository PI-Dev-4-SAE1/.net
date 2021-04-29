using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class LikeKinderGarten
    {
        public int like_id { get; set; }
        public bool is_Liked { get; set; }
        public Interaction_type like_type { get; set; }
        public Parents parents { get; set; }
        public childrengarden childrengarden { get; set; }

    }
}