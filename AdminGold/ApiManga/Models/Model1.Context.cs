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
    
    public partial class MangaEntities : DbContext
    {
        public MangaEntities()
            : base("name=MangaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblTypeManga> tblTypeMangas { get; set; }
        public virtual DbSet<tblChapterManga> tblChapterMangas { get; set; }
        public virtual DbSet<tblImgManga> tblImgMangas { get; set; }
        public virtual DbSet<tblAdvertManga> tblAdvertMangas { get; set; }
        public virtual DbSet<tblDeviceManga> tblDeviceMangas { get; set; }
    }
}
