using ApiManga.Contex;
using ApiManga.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace ApiManga.Controllers
{
    public class AdvertController : ApiController
    {
        //private ConnectContext db = new ConnectContext();

        /// <summary>
        /// TypeStatusAdvertManga 
        /// 1:Truyện đặc biệt
        /// 2:Truyện đọc nhìu
        /// 3:truyện phổ biến
        /// </summary>

        private MangaEntities db = new MangaEntities();
        //[System.Web.Http.Route("api/Advert/GetListAdvert")]
        //[System.Web.Http.HttpGet]
        public List<tblAdvertManga> GetListAdvert()
        {
            return db.tblAdvertMangas.Where(x=>x.StatusAdvertManga==1).OrderByDescending(x => x.IdAdvertManga).ToList();
        }
      
        //[System.Web.Http.Route("api/Advert/GetAdvertById")]
        //[System.Web.Http.HttpGet]
        public List<clsAllAdvert> GetAdvertById(int id)
        {
          
            var data = from dataAdvert in db.tblAdvertMangas
                       where dataAdvert.IdAdvertManga==id && dataAdvert.StatusAdvertManga==1
                       select new clsAllAdvert { tblAdvertManga= dataAdvert,ListChapterManga= db.tblChapterMangas.Where(x=>x.IdAdvertManga==id).ToList() };
            return data.ToList();
         }
        [System.Web.Http.Route("api/Advert/GetAdvertByTypeId")]
        [System.Web.Http.HttpGet]
        public List<tblAdvertManga> GetAdvertByTypeId(int id)
        {
            var getId = db.tblAdvertMangas.Select(x => x.TypeStatusAdvertManga).ToList();
            // getId.Contains( x.TypeStatusAdvertManga)
            return db.tblAdvertMangas.Where(x => x.StatusAdvertManga == 1 && x.TypeStatusAdvertManga==id).OrderByDescending(x => x.IdAdvertManga).ToList();
        }

    }
}
