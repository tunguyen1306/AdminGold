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
    public class AdminDogeController : Controller
    {
        private Manga1Entities db = new Manga1Entities();

        // GET: AdminDoge
        public ActionResult Index()
        {
            return View(db.TblDoges.ToList());
        }

        // GET: AdminDoge/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblDoge tblDoge = db.TblDoges.Find(id);
            if (tblDoge == null)
            {
                return HttpNotFound();
            }
            return View(tblDoge);
        }

        // GET: AdminDoge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminDoge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Status,Money,Pass")] TblDoge tblDoge)
        {
            if (ModelState.IsValid)
            {
                db.TblDoges.Add(tblDoge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblDoge);
        }

        // GET: AdminDoge/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblDoge tblDoge = db.TblDoges.Find(id);
            if (tblDoge == null)
            {
                return HttpNotFound();
            }
            return View(tblDoge);
        }

        // POST: AdminDoge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Status,Money,Pass")] TblDoge tblDoge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDoge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblDoge);
        }

        // GET: AdminDoge/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblDoge tblDoge = db.TblDoges.Find(id);
            if (tblDoge == null)
            {
                return HttpNotFound();
            }
            return View(tblDoge);
        }

        // POST: AdminDoge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblDoge tblDoge = db.TblDoges.Find(id);
            db.TblDoges.Remove(tblDoge);
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
