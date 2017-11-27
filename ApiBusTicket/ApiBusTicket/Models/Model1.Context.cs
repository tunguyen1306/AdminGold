﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiBusTicket.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BusEntities : DbContext
    {
        public BusEntities()
            : base("name=BusEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryText> CountryTexts { get; set; }
        public virtual DbSet<Description_service> Description_services { get; set; }
        public virtual DbSet<DICHVU> DICHVUs { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<DistrictText> DistrictTexts { get; set; }
        public virtual DbSet<DMHOADON> DMHOADONs { get; set; }
        public virtual DbSet<DMTAIXE> DMTAIXEs { get; set; }
        public virtual DbSet<DMTRAM> DMTRAMs { get; set; }
        public virtual DbSet<DMTUYEN> DMTUYENs { get; set; }
        public virtual DbSet<DMTUYENCHITIETTRAM> DMTUYENCHITIETTRAMs { get; set; }
        public virtual DbSet<DMXE> DMXEs { get; set; }
        public virtual DbSet<Docso> Docsoes { get; set; }
        public virtual DbSet<GeoTableView> GeoTableViews { get; set; }
        public virtual DbSet<HIENTHI> HIENTHIs { get; set; }
        public virtual DbSet<LCD> LCDs { get; set; }
        public virtual DbSet<LCDKio> LCDKios { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationText> LocationTexts { get; set; }
        public virtual DbSet<LOTRINHCHOXE> LOTRINHCHOXEs { get; set; }
        public virtual DbSet<PGD> PGDs { get; set; }
        public virtual DbSet<PHAN_LOAI_PGD> PHAN_LOAI_PGDs { get; set; }
        public virtual DbSet<Quarter> Quarters { get; set; }
        public virtual DbSet<QuarterText> QuarterTexts { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<StateText> StateTexts { get; set; }
        public virtual DbSet<TrackingGP> TrackingGPS { get; set; }
        public virtual DbSet<TrackingGPSDetail> TrackingGPSDetails { get; set; }
        public virtual DbSet<GeoIP2CityText> GeoIP2CityText { get; set; }
        public virtual DbSet<Ip2City> Ip2City { get; set; }
        public virtual DbSet<Ip2City2> Ip2City2 { get; set; }
        public virtual DbSet<phuong> phuongs { get; set; }
        public virtual DbSet<VNELocation> VNELocations { get; set; }
    }
}
