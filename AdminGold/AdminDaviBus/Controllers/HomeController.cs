using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminGold.Models;

namespace AdminDaviBus.Controllers
{
    public class HomeController : Controller
    {
        private BusTicketEntities db=new BusTicketEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoTrinh()
        {
            return View();
        }
        public ActionResult LoTrinh1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetTracking(string maTuyen)
        {
            var data = (from dataTr in db.TrackingGPS
                join dataTrde in db.TrackingGPSDetails on dataTr.IdTracking equals dataTrde.IdTracking
                join dataTram in db.DMTRAMs on dataTrde.MaTram equals dataTram.MATRAM
                where dataTr.MaTuyen == maTuyen
                select new {dt1= dataTr,dt2= dataTrde,dt3=dataTram }).OrderByDescending(x=>x.dt2.Id).FirstOrDefault();
            return Json(new {result= data });
        }
        [HttpPost]
        public ActionResult PostData(string text)
        {
            try
            {
                PostData data = new PostData { PostDate = DateTime.Now, PostText = text };
                db.Entry(data).State = EntityState.Added;
                db.SaveChanges();
                return Json(new { result = text, status = true });
            }
            catch (Exception)
            {


                return Json(new { result = text, status = false });
            }
        }
        public ActionResult FlotCharts()
        {
            return View("FlotCharts");
        }

        public ActionResult MorrisCharts()
        {
            return View("MorrisCharts");
        }

        public ActionResult Tables()
        {
            return View("Tables");
        }

        public ActionResult Forms()
        {
            return View("Forms");
        }

        public ActionResult Panels()
        {
            return View("Panels");
        }

        public ActionResult Buttons()
        {
            return View("Buttons");
        }

        public ActionResult Notifications()
        {
            return View("Notifications");
        }

        public ActionResult Typography()
        {
            return View("Typography");
        }

        public ActionResult Icons()
        {
            return View("Icons");
        }

        public ActionResult Grid()
        {
            return View("Grid");
        }

        public ActionResult Blank()
        {
            return View("Blank");
        }

        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email=="davibus@gmail.com" && password=="admin1234")
            {   Session["user"] = "davibus@gmail.com";
               

            }
            return RedirectToAction("Index", "Home"); ;
        }

    }
}