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
            return db.tblAdvertMangas.Where(x=>x.StatusAdvertManga==1).OrderByDescending(x => x.CountView).ToList();
        }

        [System.Web.Http.Route("api/Advert/GetAdvertById")]
        [System.Web.Http.HttpGet]
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
            return db.tblAdvertMangas.Where(x => x.StatusAdvertManga == 1 && x.TypeStatusAdvertManga==id).OrderByDescending(x => x.CountView).ToList();
        }

        [System.Web.Http.Route("api/Advert/GetAdvertWithChap")]
        [System.Web.Http.HttpGet]
        public List<clsAllAdvert> GetAdvertWithChap()
        {
            var data = from dataAdvert in db.tblAdvertMangas
                       where  dataAdvert.StatusAdvertManga == 1
                       select new clsAllAdvert { tblAdvertManga = dataAdvert, ListChapterManga = db.tblChapterMangas.Where(x => x.IdAdvertManga == dataAdvert.IdAdvertManga).ToList() };
            return data.ToList();
        }
        //[System.Web.Http.Route("api/Advert/GetAdvertByType")]
        //[System.Web.Http.HttpGet]
        //public List<tblAdvertManga> GetAdvertByType(int id)
        //{
        //    var t = new List<string>();
        //    var t1 = new List<string>();
        //    var getId = db.tblAdvertMangas.Select(x => x.AllTypeAdvertManga).ToList();
        //    var list = new List<tblAdvertManga>();
        //    foreach (var item in getId)
        //    {
        //         t= item.Split(',').ToList();

        //    }
        //   var u= t;
        //    if (id==1)
        //    {
        //        list= db.tblAdvertMangas.Where(x => x.StatusAdvertManga == 1 && x.TypeStatusAdvertManga==1 || t.Contains(x.TypeStatusAdvertManga.ToString())).OrderByDescending(x => x.IdAdvertManga).ToList();
        //    }
        //    if (id == 2)
        //    {
        //        list = db.tblAdvertMangas.Where(x => x.StatusAdvertManga == 1 && x.TypeStatusAdvertManga == 2 || t.Contains(x.TypeStatusAdvertManga.ToString())).OrderByDescending(x => x.IdAdvertManga).ToList();
        //    }
        //    if (id == 3)
        //    {
        //        list = db.tblAdvertMangas.Where(x => x.StatusAdvertManga == 1 && x.TypeStatusAdvertManga == 3 || t.Contains(x.TypeStatusAdvertManga.ToString())).OrderByDescending(x => x.IdAdvertManga).ToList();
        //    }


        //    // getId.Contains( x.TypeStatusAdvertManga)
        //    return list;
        //}
        [System.Web.Http.Route("api/Advert/CountView")]
        [System.Web.Http.HttpGet]
        public List<tblAdvertManga> CountView(int id,int idcount)
        {
            var view = db.tblAdvertMangas.Where(x => x.IdAdvertManga == id).FirstOrDefault().CountView;
           
            if (idcount == 123)
            {
                tblAdvertManga tblAdvertManga = db.tblAdvertMangas.Find(id);
                tblAdvertManga.CountView = view + 1;
                db.Entry(tblAdvertManga).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            return db.tblAdvertMangas.Where(x => x.StatusAdvertManga == 1 && x.IdAdvertManga == id).ToList();
        }
        [System.Web.Http.Route("api/Advert/GetListAdvertByType")]
        [System.Web.Http.HttpGet]
        public List<tblAdvertManga> GetListAdvertByType(string type)
        {
            List<string> typei=new List<string>();
            if (type.EndsWith(","))
            {
                type = type.Remove(type.Length-1).Replace(", ","");
               
            }
            typei = type.Split(',').ToList();
            // && typei.Contains(x.TypeAdvertManga)
            return db.tblAdvertMangas.Where(x => x.StatusAdvertManga == 1 && type.Contains(x.TypeAdvertManga)).OrderByDescending(x => x.CountView).ToList();
        }
        [System.Web.Http.Route("api/Advert/test")]
        [System.Web.Http.HttpGet]
        public List<clsAllAdvert> test()
        {
            int i = 0;
            var sqlquery = from data in db.tblAdvertMangas
                           where data.StatusAdvertManga == 1
                           select new clsAllAdvert { tblAdvertManga = data, row_num = i };
            return sqlquery.Select((x, index) => new clsAllAdvert { row_num = index, tblAdvertManga = x.tblAdvertManga }).ToList();//db.tblAdvertMangas.Where(x=>x.StatusAdvertManga==1).OrderByDescending(x => x.CountView).Select((x, i) => new clsAllAdvert { row_num = i,tblAdvertManga=x  }).ToList();
        }

    }
}
