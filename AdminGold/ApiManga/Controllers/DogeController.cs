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
        public IHttpActionResult AddUser(string username,string pass,string money,int status)
        {
            try
            {
                var tblDoge = new TblDoge
                {
                    UserName = username,
                    Pass = pass,
                    Money = money,
                    Status = status

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

    }
}