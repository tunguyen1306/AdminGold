﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiManga.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Manga1Entities : DbContext
    {
        public Manga1Entities()
            : base("name=Manga1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryText> CountryTexts { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<DistrictText> DistrictTexts { get; set; }
        public virtual DbSet<DMTRAM> DMTRAMs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationText> LocationTexts { get; set; }
        public virtual DbSet<Quarter> Quarters { get; set; }
        public virtual DbSet<QuarterText> QuarterTexts { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<StateText> StateTexts { get; set; }
        public virtual DbSet<tbl_advert_promotion> tbl_advert_promotion { get; set; }
        public virtual DbSet<tbl_brand_promotion> tbl_brand_promotion { get; set; }
        public virtual DbSet<tbl_category_promotion> tbl_category_promotion { get; set; }
        public virtual DbSet<tbl_slide_promotion> tbl_slide_promotion { get; set; }
        public virtual DbSet<tbl_user_promotion> tbl_user_promotion { get; set; }
        public virtual DbSet<tblAdvertGift> tblAdvertGifts { get; set; }
        public virtual DbSet<tblAdvertManga> tblAdvertMangas { get; set; }
        public virtual DbSet<tblCategoryGift> tblCategoryGifts { get; set; }
        public virtual DbSet<tblChapterManga> tblChapterMangas { get; set; }
        public virtual DbSet<tblCityGift> tblCityGifts { get; set; }
        public virtual DbSet<tblDeviceManga> tblDeviceMangas { get; set; }
        public virtual DbSet<tblImgManga> tblImgMangas { get; set; }
        public virtual DbSet<tblTypeGift> tblTypeGifts { get; set; }
        public virtual DbSet<tblTypeManga> tblTypeMangas { get; set; }
        public virtual DbSet<tbl_advert_picture_promotion> tbl_advert_picture_promotion { get; set; }
        public virtual DbSet<TblDoge> TblDoges { get; set; }
    }
}
