using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APImyPromotion.Models;

namespace APImyPromotion.Controllers
{
    public class AdvertMangasController : ApiController
    {
        private MyPromotionEntities db = new MyPromotionEntities();


        public List<tblAdvertManga> GetListAdvert()
        {
            return db.tblAdvertMangas.ToList();
        }
    }
}