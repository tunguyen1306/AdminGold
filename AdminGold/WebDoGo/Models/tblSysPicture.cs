//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDoGo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSysPicture
    {
        public int picture_id { get; set; }
        public Nullable<int> advert_id { get; set; }
        public string originalFilepath { get; set; }
        public Nullable<byte> position { get; set; }
        public Nullable<System.DateTime> converted { get; set; }
        public string convertedFilename { get; set; }
        public Nullable<bool> tocheck { get; set; }
        public Nullable<bool> isvalidated { get; set; }
        public string convertedFilename90 { get; set; }
        public string convertedFilename180 { get; set; }
        public string convertedFilename270 { get; set; }
        public Nullable<byte> angleType { get; set; }
        public Nullable<byte> type_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Nullable<int> cms_sql_id { get; set; }
        public string shortdescription { get; set; }
    }
}
