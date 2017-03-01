using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminGold.Models
{
    public class GeoModel
    {
        public int IdCity { get; set; }
        public string NameCity { get; set; }
        public int LatitudeCity { get; set; }
        public string LongtitudeCity { get; set; }

        public int IdDistrict { get; set; }
        public string NameDistrict { get; set; }
        public int LatitudeDistrict { get; set; }
        public string LongtitudeDistrict { get; set; }


        public int IdWard{ get; set; }
        public string NameWard { get; set; }
        public int LatitudeWard { get; set; }
        public string LongtitudeWard { get; set; }
    }
}