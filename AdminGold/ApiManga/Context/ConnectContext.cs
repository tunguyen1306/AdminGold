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
        public DbSet<tblAdvertManga> tblAdvertManga { get; set; }
    }
}