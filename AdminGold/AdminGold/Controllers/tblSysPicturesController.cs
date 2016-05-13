using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminGold.Models;

namespace AdminGold.Controllers
{
    public class tblSysPicturesController : Controller
    {
        private AdminGoldEntities db = new AdminGoldEntities();

        // GET: tblSysPictures
        public ActionResult Index()
        {
            return View(db.tblSysPictures.ToList());
        }

        // GET: tblSysPictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSysPicture tblSysPicture = db.tblSysPictures.Find(id);
            if (tblSysPicture == null)
            {
                return HttpNotFound();
            }
            return View(tblSysPicture);
        }

        // GET: tblSysPictures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblSysPictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "picture_id,advert_id,originalFilepath,position,converted,convertedFilename,tocheck,isvalidated,convertedFilename90,convertedFilename180,convertedFilename270,angleType,type_id,title,description,cms_sql_id,shortdescription")] tblSysPicture tblSysPicture)
        {
            if (ModelState.IsValid)
            {
                db.tblSysPictures.Add(tblSysPicture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSysPicture);
        }

        // GET: tblSysPictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSysPicture tblSysPicture = db.tblSysPictures.Find(id);
            if (tblSysPicture == null)
            {
                return HttpNotFound();
            }
            return View(tblSysPicture);
        }

        // POST: tblSysPictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "picture_id,advert_id,originalFilepath,position,converted,convertedFilename,tocheck,isvalidated,convertedFilename90,convertedFilename180,convertedFilename270,angleType,type_id,title,description,cms_sql_id,shortdescription")] tblSysPicture tblSysPicture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSysPicture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSysPicture);
        }

        // GET: tblSysPictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSysPicture tblSysPicture = db.tblSysPictures.Find(id);
            if (tblSysPicture == null)
            {
                return HttpNotFound();
            }
            return View(tblSysPicture);
        }

        // POST: tblSysPictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSysPicture tblSysPicture = db.tblSysPictures.Find(id);
            db.tblSysPictures.Remove(tblSysPicture);
            db.SaveChanges();
            return RedirectToAction("Index");
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
