using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiManga.Contex;
using ApiManga.Models;

namespace ApiManga.Controllers
{
    public class AdminAdvertMangasController : Controller
    {
        private ConnectContext db = new ConnectContext();

        // GET: AdminAdvertMangas
        public ActionResult Index()
        {
            return View(db.tblAdvertMangas.ToList());
        }

        // GET: AdminAdvertMangas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdvertManga tblAdvertManga = db.tblAdvertMangas.Find(id);
            if (tblAdvertManga == null)
            {
                return HttpNotFound();
            }
            return View(tblAdvertManga);
        }

        // GET: AdminAdvertMangas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminAdvertMangas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdvertManga,NameAdvertManga,DesAdvertManga,NameAuthorAdvertManga,StatusAdvertManga,StatusChapAdvertManga,CountChapAdvertManga,TypeAdvertManga,ImgAdvertManga")] tblAdvertManga tblAdvertManga)
        {
            if (ModelState.IsValid)
            {
                db.tblAdvertMangas.Add(tblAdvertManga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAdvertManga);
        }

        // GET: AdminAdvertMangas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdvertManga tblAdvertManga = db.tblAdvertMangas.Find(id);
            if (tblAdvertManga == null)
            {
                return HttpNotFound();
            }
            return View(tblAdvertManga);
        }

        // POST: AdminAdvertMangas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdvertManga,NameAdvertManga,DesAdvertManga,NameAuthorAdvertManga,StatusAdvertManga,StatusChapAdvertManga,CountChapAdvertManga,TypeAdvertManga,ImgAdvertManga")] tblAdvertManga tblAdvertManga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAdvertManga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAdvertManga);
        }

        // GET: AdminAdvertMangas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAdvertManga tblAdvertManga = db.tblAdvertMangas.Find(id);
            if (tblAdvertManga == null)
            {
                return HttpNotFound();
            }
            return View(tblAdvertManga);
        }

        // POST: AdminAdvertMangas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAdvertManga tblAdvertManga = db.tblAdvertMangas.Find(id);
            db.tblAdvertMangas.Remove(tblAdvertManga);
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
