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
    
    public partial class tblProduct
    {
        public int IdProducts { get; set; }
        public string NameProducts { get; set; }
        public Nullable<int> IdCategoryProducts { get; set; }
        public string PriceProducts { get; set; }
        public string ShortDesProducts { get; set; }
        public string DescriptionProducts { get; set; }
        public Nullable<int> StatusProducts { get; set; }
        public Nullable<System.DateTime> CreateDateProducts { get; set; }
        public Nullable<System.DateTime> ModifiDateProducts { get; set; }
        public string CreateUserProducts { get; set; }
        public string ModifiUserProducts { get; set; }
        public string NameProducts_en { get; set; }
        public string ShortDesProducts_en { get; set; }
        public string DescriptionProducts_en { get; set; }
        public Nullable<int> IdTypeProducts { get; set; }
    }
}