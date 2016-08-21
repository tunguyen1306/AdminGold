using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiPromotion.Models
{
    public class clTblUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Nullable<int> type_role { get; set; }
        public Nullable<int> status { get; set; }
        public string pass { get; set; }
    }
}