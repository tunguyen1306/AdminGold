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

namespace ApiManga.Controllers
{
    public class ChapterController : ApiController
    {
        private MangaEntities db = new MangaEntities();

        public List<tblChapterManga> GetChapByAdvertID(int id)
        {

            var date = from dataAdvert in db.tblAdvertMangas
                       where dataAdvert.IdAdvertManga == id && dataAdvert.StatusAdvertManga == 1
                       select new clsAllAdvert { tblAdvertManga = dataAdvert, ListChapterManga = db.tblChapterMangas.Where(x => x.IdAdvertManga == id).ToList() };
            return db.tblChapterMangas.Where(x => x.StatusChapterManga == 1 && x.IdAdvertManga == id).OrderByDescending(x=>x.IdChapterManga).ToList();
        }
    }
}