using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APImyPromotion.Models
{
    public class BrandDto
    {
        public int id_brand_promotiom { get; set; }
        public string name_brand_promotiom { get; set; }
        public string address_brand_promotiom { get; set; }
        public Nullable<int> percent_brand_promotiom { get; set; }
        public Nullable<int> status_brand_promotiom { get; set; }
        public Nullable<int> type_brand_promotiom { get; set; }
        public string phone_brand_promotiom { get; set; }
        public string working_brand_promotiom { get; set; }
        public Nullable<int> advert_id_brand_promotiom { get; set; }
        public string img_brand_promotiom { get; set; }
        public string short_des_brand_promotion { get; set; }
        public string start_date_brand_promotion { get; set; }
        public string end_date_brand_promotion { get; set; }
        public Nullable<System.DateTime> created_date_brand_promotion { get; set; }
        public Nullable<System.DateTime> modifi_date_brand_promotion { get; set; }
        public string create_user_brand_promotion { get; set; }
        public string modifi_user_brand_promotion { get; set; }
        public int category_id_brand_promotion { get; set; }
    }
}