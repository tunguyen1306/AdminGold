using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APImyPromotion.Models
{
    public class SlideDto
    {
        public int id_slide { get; set; }
        public string img_slide { get; set; }
        public string title_slide { get; set; }
        public string des_slide { get; set; }
        public int status_slide { get; set; }
    }
}