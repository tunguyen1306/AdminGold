//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APImyPromotion.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_advert_picture_promotion
    {
        public int picture_id { get; set; }
        public int advert_id { get; set; }
        public string originalFilepath { get; set; }
        public byte position { get; set; }
        public Nullable<System.DateTime> converted { get; set; }
        public string convertedFilename { get; set; }
        public bool tocheck { get; set; }
        public bool isvalidated { get; set; }
        public string convertedFilename90 { get; set; }
        public string convertedFilename180 { get; set; }
        public string convertedFilename270 { get; set; }
        public byte angleType { get; set; }
        public byte type_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Nullable<int> cms_sql_id { get; set; }
        public string shortdescription { get; set; }
    }
}
