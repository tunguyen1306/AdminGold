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
    
    public partial class sys_mapped_join
    {
        public int id_mapped_join { get; set; }
        public Nullable<int> mapped_table_parent { get; set; }
        public Nullable<int> referencedTableName { get; set; }
        public string ref_name { get; set; }
        public Nullable<int> id_mapped_col_p { get; set; }
        public Nullable<int> id_mapped_col_c { get; set; }
    }
}
