﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APISendGift.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ApiGiftEntities : DbContext
    {
        public ApiGiftEntities()
            : base("name=ApiGiftEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAdvertGift> tblAdvertGifts { get; set; }
        public virtual DbSet<tblCategoryGift> tblCategoryGifts { get; set; }
        public virtual DbSet<tblCityGift> tblCityGifts { get; set; }
        public virtual DbSet<tblTypeGift> tblTypeGifts { get; set; }
    }
}
