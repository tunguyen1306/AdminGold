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
using ApiManga.Models;
using System.Xml.Linq;
using System.Web;
using System.Xml;

namespace ApiManga.Controllers
{
    public class ChapterController : ApiController
    {
        private MangaEntities db = new MangaEntities();
        //[System.Web.Http.Route("api/Advert/GetChapByAdvertID")]
        //[System.Web.Http.HttpGet]
        public List<tblChapterManga> GetChapByAdvertID(int id)
        {

            var date = from dataAdvert in db.tblAdvertMangas
                       where dataAdvert.IdAdvertManga == id && dataAdvert.StatusAdvertManga == 1
                       select new clsAllAdvert { tblAdvertManga = dataAdvert, ListChapterManga = db.tblChapterMangas.Where(x => x.IdAdvertManga == id).ToList() };
            return db.tblChapterMangas.Where(x => x.StatusChapterManga == 1 && x.IdAdvertManga == id).OrderByDescending(x => x.IdChapterManga).ToList();
        }
        [System.Web.Http.Route("api/Chapter/GetDetailChapByID")]
        [System.Web.Http.HttpGet]
        public List<clsChapterDto> GetDetailChapByID(int idChap)
        {
            var file = db.tblImgMangas.Where(x => x.IdChapterManga == idChap).ToList();
            XmlDocument document = new XmlDocument();
            foreach (var item in file)
            {
                document.Load(item.ImgManga);
            }

            // Load XML File

            XmlNodeList nodes = document.SelectNodes("/ChapterItem/ListImg/ImgChapter");
            var products = new List<string>();

            foreach (XmlNode item in nodes)
            {

                products.Add(item.InnerText);

            }
            var dt = (from dta in products select new clsChapterDto { Link = dta }).ToList();
            return dt;
        }
        [System.Web.Http.Route("api/Chapter/CountUpdate")]
        [System.Web.Http.HttpGet]
        public List<clsChapterDto> CountUpdate()
        {
            var date = DateTime.Now.AddDays(-5);
            var sqlCountChap = (from dataChap in db.tblChapterMangas
                                where dataChap.StatusChapterManga == 1 && dataChap.DateChapterManga > date
                                select dataChap).ToList().Count();
            var sqlData = (from dataAdvert in db.tblAdvertMangas
                           where dataAdvert.StatusAdvertManga == 1
                           select dataAdvert).ToList();


            List<clsChapterDto> cl = new List<clsChapterDto>();

            foreach (var item in sqlData)
            {
                cl.Add(new clsChapterDto
                {
                    num_update = (from dataChap in db.tblChapterMangas
                                  where dataChap.StatusChapterManga == 1 && dataChap.DateChapterManga > date && dataChap.IdAdvertManga == item.IdAdvertManga
                                  select dataChap).ToList().Count(),
                    IdAdvertManga = item.IdAdvertManga,
                    NameAdvertManga = item.NameAdvertManga,
                    DesAdvertManga = item.DesAdvertManga,
                    NameAuthorAdvertManga = item.NameAuthorAdvertManga,
                    CodeAdvertManga = item.CodeAdvertManga,
                    CountView = item.CountView,
                    CountChapAdvertManga = item.CountChapAdvertManga,
                    TypeAdvertManga = item.TypeAdvertManga,
                    ImgAdvertManga = item.ImgAdvertManga,
                    AlltypeAdvertManga = item.AlltypeAdvertManga,
                    TypeStatusAdvertManga = item.TypeStatusAdvertManga,
                    StatusAdvertManga=item.StatusAdvertManga,
                   StatusChapAdvertManga=item.StatusChapAdvertManga



                }
                );
            }




            return cl;
        }

    }
}