using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APImyPromotion.Models
{
    public class UserDto
    {
        
        public int IDout { get; set; }
        public int id_user_promotion { get; set; }
        public string email_user_promotion { get; set; }
        public string phone_user_promotion { get; set; }
        public string first_name_user_promotion { get; set; }
        public string last_name_user_promotion { get; set; }
        public int? type_role_user_promotion { get; set; }
        public int? status_user_promotion { get; set; }
        public string pass_user_promotion { get; set; }
        public string img_user_promotion { get; set; }
        public string full_name_user_promotion { get; set; }
    }
}