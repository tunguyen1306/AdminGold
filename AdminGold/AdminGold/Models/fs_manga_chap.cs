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
    
    public partial class fs_manga_chap
    {
        public long chap_id { get; set; }
        public Nullable<long> manga_id { get; set; }
        public string chap_name { get; set; }
        public Nullable<int> chap_orther { get; set; }
        public Nullable<System.DateTime> chap_create { get; set; }
        public string chap_key { get; set; }
    }
}
