using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminDaviBus.Models
{
    public class clsBlog
    {
        public int id_blog_tra { get; set; }
        public string titile_blog_tra { get; set; }
        public string short_des_blog_tra { get; set; }
        public string des_blog_tra { get; set; }
        public Nullable<int> status_blog_tra { get; set; }
        public Nullable<int> type_blog_tra { get; set; }
        public Nullable<System.DateTime> create_date_blog_tra { get; set; }
        public string img_blog_tra { get; set; }

        public string link_img_blog_tra { get; set; }
        public string video_blog_tra { get; set; }
    }
}