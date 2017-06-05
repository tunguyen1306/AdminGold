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
using ApiManga.Contex;
using ApiManga.Models;

namespace ApiManga.Controllers
{
    public class DogeController : ApiController
    {
        private Manga1Entities db = new Manga1Entities();
        [System.Web.Http.Route("api/Doge/AddUser")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult AddUser(string username,string pass,string createdate,String ipserver, int status)
        {
            try
            {
                var tblDoge = new TblDoge
                {
                    UserName = username,
                    Pass = pass,
                    Money = "0",
                    Status = status,
                    CreateDate = new DateTime(long.Parse(createdate)).ToString(),
                    ipServer = ipserver,
                    statusEnd=0,
                    statusStart=0


                };
                db.TblDoges.Add(tblDoge);
                db.SaveChanges();
                return Json(new { Result = "1" });
            }
            catch (Exception x)
            {
            return Json(new { Result = x });
                throw;
               
            }
           


            
        }
        [System.Web.Http.Route("api/Doge/UpdateStatusStart")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult UpdateStatusStart(string username,int statusstart)
        {
            try
            {

                var tblDoge = db.TblDoges.Where(x=>x.UserName==username).Select(x=>x.Id).FirstOrDefault();
                TblDoge tbl = db.TblDoges.Find(tblDoge);
                tbl.statusStart = statusstart;
                db.Entry(tbl).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { Result = "1" });
            }
            catch (Exception x)
            {
                return Json(new { Result = x });
                throw;

            }




        }
        [System.Web.Http.Route("api/Doge/UpdateStatusEnd")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult UpdateStatusEnd(string username, int statusend)
        {
            try
            {

                var tblDoge = db.TblDoges.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
                TblDoge tbl = db.TblDoges.Find(tblDoge);
                tbl.statusEnd = statusend;
                db.Entry(tbl).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { Result = "1" });
            }
            catch (Exception x)
            {
                return Json(new { Result = x });
                throw;

            }




        }
        [System.Web.Http.Route("api/Doge/UpdateMoney")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult UpdateMoney(string username, string money)
        {
            try
            {

                var tblDoge = db.TblDoges.Where(x => x.UserName == username).Select(x => x.Id).FirstOrDefault();
                TblDoge tbl = db.TblDoges.Find(tblDoge);
                tbl.Money = money;
                db.Entry(tbl).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { Result = "1" });
            }
            catch (Exception x)
            {
                return Json(new { Result = x });
                throw;

            }




        }
    }
}