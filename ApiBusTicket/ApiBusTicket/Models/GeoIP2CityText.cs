//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiBusTicket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GeoIP2CityText
    {
        public Nullable<long> geoname_id { get; set; }
        public string locale_code { get; set; }
        public string continent_code { get; set; }
        public string continent_name { get; set; }
        public string country_iso_code { get; set; }
        public string country_name { get; set; }
        public string subdivision_1_iso_code { get; set; }
        public string subdivision_1_name { get; set; }
        public string subdivision_2_iso_code { get; set; }
        public string subdivision_2_name { get; set; }
        public string city_name { get; set; }
        public string metro_code { get; set; }
        public string time_zone { get; set; }
        public System.Guid rowguid { get; set; }
    }
}