using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiManga.Models;

namespace ApiManga.Controllers
{
    public class AdminTypeMangasController : Controller
    {
        private MangaEntities db = new MangaEntities();

        // GET: AdminTypeMangas
        public ActionResult Index()
        {
            return View(db.tblTypeMangas.ToList());
        }

        // GET: AdminTypeMangas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTypeManga tblTypeManga = db.tblTypeMangas.Find(id);
            if (tblTypeManga == null)
            {
                return HttpNotFound();
            }
            return View(tblTypeManga);
        }

        // GET: AdminTypeMangas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminTypeMangas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTypeManga,NameTypeManga,StatusTypeManga")] tblTypeManga tblTypeManga)
        {
            if (ModelState.IsValid)
            {
                db.tblTypeMangas.Add(tblTypeManga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblTypeManga);
        }

        // GET: AdminTypeMangas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTypeManga tblTypeManga = db.tblTypeMangas.Find(id);
            if (tblTypeManga == null)
            {
                return HttpNotFound();
            }
            return View(tblTypeManga);
        }

        // POST: AdminTypeMangas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTypeManga,NameTypeManga,StatusTypeManga")] tblTypeManga tblTypeManga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTypeManga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblTypeManga);
        }

        // GET: AdminTypeMangas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTypeManga tblTypeManga = db.tblTypeMangas.Find(id);
            if (tblTypeManga == null)
            {
                return HttpNotFound();
            }
            return View(tblTypeManga);
        }

        // POST: AdminTypeMangas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTypeManga tblTypeManga = db.tblTypeMangas.Find(id);
            db.tblTypeMangas.Remove(tblTypeManga);
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
