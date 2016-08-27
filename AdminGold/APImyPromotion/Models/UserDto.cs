using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APImyPromotion.Models
{
    public class UserDto
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int? type_role { get; set; }
        public int? status { get; set; }
        public string pass { get; set; }
        public int IDout { get; set; }
        public string img_url { get; set; }
    }
}