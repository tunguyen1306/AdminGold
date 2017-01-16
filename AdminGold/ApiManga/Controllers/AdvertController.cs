using ApiManga.Contex;
using ApiManga.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace ApiManga.Controllers
{
    public class AdvertController : ApiController
    {
        //private ConnectContext db = new ConnectContext();
        private MangaEntities db = new MangaEntities();
        public List<tblAdvertManga> GetListAdvert()
        {
            return db.tblAdvertMangas.Where(x=>x.StatusAdvertManga==1).ToList();
        }

    }
}
