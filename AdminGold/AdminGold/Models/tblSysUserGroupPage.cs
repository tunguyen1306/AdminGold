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
    
    public partial class tblSysUserGroupPage
    {
        public int role_group_page_id { get; set; }
        public string role_group_page_name { get; set; }
        public string role_group_page_des { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public Nullable<int> update_by { get; set; }
        public Nullable<int> create_by { get; set; }
        public int id_company { get; set; }
        public Nullable<int> role_group_status { get; set; }
        public Nullable<int> role_page_view { get; set; }
        public Nullable<int> role_page_create { get; set; }
        public Nullable<int> role_page_del { get; set; }
    }
}
