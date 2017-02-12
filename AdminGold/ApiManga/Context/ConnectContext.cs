using ApiManga.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiManga.Contex
{
    public class ConnectContext:DbContext
    {
        public ConnectContext():base("ConnectContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblTypeManga>().HasKey(c => c.IdTypeManga);
            modelBuilder.Entity<tblTypeManga>().Property(p => p.NameTypeManga).HasColumnType("NVARCHAR").HasMaxLength(500);

            modelBuilder.Entity<tblAdvertManga>().HasKey(c => c.IdAdvertManga);
            modelBuilder.Entity<tblAdvertManga>().Property(p => p.NameAdvertManga).HasColumnType("NVARCHAR").HasMaxLength(500);
            modelBuilder.Entity<tblAdvertManga>().Property(p => p.DesAdvertManga).HasColumnType("NVARCHAR");
            modelBuilder.Entity<tblAdvertManga>().Property(p => p.NameAuthorAdvertManga).HasColumnType("NVARCHAR").HasMaxLength(500);
            modelBuilder.Entity<tblAdvertManga>().Property(p => p.StatusAdvertManga).HasColumnType("INT");
            modelBuilder.Entity<tblAdvertManga>().Property(p => p.StatusChapAdvertManga).HasColumnType("INT");
            modelBuilder.Entity<tblAdvertManga>().Property(p => p.TypeAdvertManga).HasColumnType("NVARCHAR").HasMaxLength(500);
            modelBuilder.Entity<tblAdvertManga>().Property(p => p.ImgAdvertManga).HasColumnType("NVARCHAR");
            modelBuilder.Entity<tblAdvertManga>().Property(p => p.CountChapAdvertManga).HasColumnType("INT");
        }
    
       public DbSet<tblAdvertManga> tblAdvertMangas { get; set; }
        public DbSet<tblTypeManga> tblTypeMangas { get; set; }
    }
}