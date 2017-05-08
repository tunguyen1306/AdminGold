using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminGold.Models;

namespace AdminGold.Controllers
{
    public class tbl_blog_traController : Controller
    {
        private AdminGoldEntities db = new AdminGoldEntities();

        // GET: tbl_blog_tra
        public ActionResult Index()
        {
            var query = from data in db.tbl_blog_tra
                        where data.id_company==1 && data.status_blog_tra==1
                        select data;
            return View(query.ToList());
        }
        public ActionResult IndexVG()
        {
            var query = from data in db.tbl_blog_tra
                        where data.id_company ==2 && data.status_blog_tra == 1
                        select data;
            return View(query.ToList());
        }
        // GET: tbl_blog_tra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_blog_tra tbl_blog_tra = db.tbl_blog_tra.Find(id);
            if (tbl_blog_tra == null)
            {
                return HttpNotFound();
            }
            return View(tbl_blog_tra);
        }

        // GET: tbl_blog_tra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_blog_tra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(tbl_blog_tra tbl_blog_tra)
        {
            if (ModelState.IsValid)
            {
                ViewBag.des_blog_tra = tbl_blog_tra.des_blog_tra;
                tbl_blog_tra.id_company = 1;
                tbl_blog_tra.create_date_blog_tra = DateTime.Now;
                db.tbl_blog_tra.Add(tbl_blog_tra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_blog_tra);
        }

        // GET: tbl_blog_tra/Create
        public ActionResult CreateVG()
        {
            return View();
        }

        // POST: tbl_blog_tra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateVG(tbl_blog_tra tbl_blog_tra)
        {
            if (ModelState.IsValid)
            {
                ViewBag.des_blog_tra = tbl_blog_tra.des_blog_tra;
                tbl_blog_tra.id_company = 2;
                tbl_blog_tra.create_date_blog_tra = DateTime.Now;
                db.tbl_blog_tra.Add(tbl_blog_tra);
                db.SaveChanges();
                return RedirectToAction("IndexVG");
            }

            return View(tbl_blog_tra);
        }


        // GET: tbl_blog_tra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_blog_tra tbl_blog_tra = db.tbl_blog_tra.Find(id);

            if (tbl_blog_tra == null)
            {
                return HttpNotFound();
            }
            return View(tbl_blog_tra);
        }

        // POST: tbl_blog_tra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(tbl_blog_tra tbl_blog_tra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_blog_tra).State = EntityState.Modified;
                tbl_blog_tra.id_company = 1;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_blog_tra);
        }

        // GET: tbl_blog_tra/Edit/5
        public ActionResult EditVG(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_blog_tra tbl_blog_tra = db.tbl_blog_tra.Find(id);
            
            if (tbl_blog_tra == null)
            {
                return HttpNotFound();
            }
            return View(tbl_blog_tra);
        }

        // POST: tbl_blog_tra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditVG(tbl_blog_tra tbl_blog_tra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_blog_tra).State = EntityState.Modified;
                tbl_blog_tra.id_company = 2;
                tbl_blog_tra.create_date_blog_tra = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("IndexVG");
            }
            return View(tbl_blog_tra);
        }

        // GET: tbl_blog_tra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_blog_tra tbl_blog_tra = db.tbl_blog_tra.Find(id);
            if (tbl_blog_tra == null)
            {
                return HttpNotFound();
            }
            db.tbl_blog_tra.Remove(tbl_blog_tra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: tbl_blog_tra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_blog_tra tbl_blog_tra = db.tbl_blog_tra.Find(id);
            db.tbl_blog_tra.Remove(tbl_blog_tra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("GetLink")]
        public JsonResult GetLink()
        {
            var path = string.Empty; var path1 = string.Empty;
            var NewPath = string.Empty;
            var fortmatName = string.Empty;
     var fileNameFull = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var file = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                if (file != null && file.ContentLength > 0)
                {

                    var fileName = Path.GetFileName(file.FileName);
                    string newFileNmae = Path.GetFileNameWithoutExtension(fileName);
                    fortmatName = Path.GetExtension(fileName);

                    NewPath = newFileNmae.Replace(newFileNmae, (DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString()).ToString());
                    fileNameFull = DateTime.Now.Day+"" + DateTime.Now.Month + "_" + NewPath + fortmatName;
                    path = Server.MapPath("~/fileUpload/") + DateTime.Now.Day + DateTime.Now.Month + "/";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    path1 = Path.Combine(path, fileNameFull);

                    file.SaveAs(path1);
                }
            }

            if (HttpContext.Request.Url != null && HttpContext.Request.Url.Host.Contains("localhost"))
            {
                path = HttpContext.Request.Url.Host + ":" + HttpContext.Request.Url.Port + "/fileUpload/" + DateTime.Now.Day + DateTime.Now.Month + "/";
            }
            else
            {
                path = ConfigurationManager.AppSettings["domain"] + DateTime.Now.Day + DateTime.Now.Month + "/";
            }
            var _fullUrl = path + fileNameFull;
            return Json(new
            {
               fullurl= _fullUrl,
               shorurl = "/fileUpload/" + DateTime.Now.Day + DateTime.Now.Month + "/"+ fileNameFull,
               imgName= fileNameFull
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
