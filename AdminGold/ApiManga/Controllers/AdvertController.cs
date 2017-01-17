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
        public List<clsAllAdvert> GetAdvertById(int id)
        {

            var date = from dataAdvert in db.tblAdvertMangas
                       where dataAdvert.IdAdvertManga==id && dataAdvert.StatusAdvertManga==1
                       select new clsAllAdvert { tblAdvertManga= dataAdvert,ListChapterManga= db.tblChapterMangas.Where(x=>x.IdAdvertManga==id).ToList() };
            return date.ToList();
         }
        //public List<tblAdvertManga> GetAdvertById(int id)
        //{
        //    var allAdvert = new clsAllAdvert
        //    {
        //        ListAdvertManga = db.tblAdvertMangas.Where(x => x.IdAdvertManga == id).ToList(),
        //        ListChapterManga = db.tblChapterMangas.Where(x => x.IdAdvertManga == id).ToList()
        //    };

        //    return db.tblAdvertMangas.Where(x => x.StatusAdvertManga == 1 && x.IdAdvertManga == id).ToList();
        //    // return allAdvert;
        //}


    }
}
