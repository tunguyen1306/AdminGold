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
        public decimal? LatitudeCity { get; set; }
        public decimal? LongtitudeCity { get; set; }
        public State tblCity { get; set; }
        public StateText tblCityText { get; set; }
        public List<State> LitsCity { get; set; }
        public List<StateText> LitsCityText { get; set; }
        public string PolygonCity { get; set; }




        public int IdDistrict { get; set; }
        public string NameDistrict { get; set; }
        public decimal? LatitudeDistrict { get; set; }
        public decimal? LongtitudeDistrict { get; set; }


        public int IdWard{ get; set; }
        public string NameWard { get; set; }
        public decimal? LatitudeWard { get; set; }
        public decimal? LongtitudeWard { get; set; }
    }
}