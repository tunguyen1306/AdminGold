//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminGold.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ip2City
    {
        public string network { get; set; }
        public string ipfrom { get; set; }
        public string ipto { get; set; }
        public Nullable<long> ipvaluefrom { get; set; }
        public Nullable<long> ipvalueto { get; set; }
        public string geoname_id { get; set; }
        public string registered_country_geoname_id { get; set; }
        public string represented_country_geoname_id { get; set; }
        public string is_anonymous_proxy { get; set; }
        public string is_satellite_provider { get; set; }
        public string postal_code { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string city { get; set; }
        public Nullable<int> cityId { get; set; }
        public System.Guid rowguid { get; set; }
    }
}
