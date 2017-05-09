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
    public class MathVGController : Controller
    {
        private VanGiaEntities db1 = new VanGiaEntities();
        private AdminGoldEntities db = new AdminGoldEntities();
        // GET: MathVG
        public ActionResult Index()
        {
            return View(db.tblMath_vangia.ToList());
        }

        // GET: MathVG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMath_vangia tblMath_vangia = db.tblMath_vangia.Find(id);
            if (tblMath_vangia == null)
            {
                return HttpNotFound();
            }
            return View(tblMath_vangia);
        }

        // GET: MathVG/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MathVG/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( tblMath_vangia tblMath_vangia)
        {
            if (ModelState.IsValid)
            {
                db.tblMath_vangia.Add(tblMath_vangia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblMath_vangia);
        }

        // GET: MathVG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMath_vangia tblMath_vangia = db.tblMath_vangia.Find(id);
            if (tblMath_vangia == null)
            {
                return HttpNotFound();
            }
            return View(tblMath_vangia);
        }

        // POST: MathVG/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( tblMath_vangia tblMath_vangia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMath_vangia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblMath_vangia);
        }

        // GET: MathVG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMath_vangia tblMath_vangia = db.tblMath_vangia.Find(id);
            if (tblMath_vangia == null)
            {
                return HttpNotFound();
            }
            return View(tblMath_vangia);
        }

        // POST: MathVG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblMath_vangia tblMath_vangia = db.tblMath_vangia.Find(id);
            db.tblMath_vangia.Remove(tblMath_vangia);
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
