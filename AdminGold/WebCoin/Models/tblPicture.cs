//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebCoin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPicture
    {
        public int PictureId { get; set; }
        public Nullable<int> ProductsId { get; set; }
        public string OriginalFilepath { get; set; }
        public Nullable<byte> Position { get; set; }
        public Nullable<System.DateTime> Converted { get; set; }
        public string ConvertedFilename { get; set; }
        public Nullable<bool> ToCheck { get; set; }
        public Nullable<bool> Isvalidated { get; set; }
        public string ConvertedFilename90 { get; set; }
        public string ConvertedFilename180 { get; set; }
        public string ConvertedFilename270 { get; set; }
        public Nullable<byte> AngleType { get; set; }
        public Nullable<byte> Type_id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
