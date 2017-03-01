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
    public class DmTuyenController : Controller
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: DmTuyen
        public ActionResult Index()
        {
            return View(db.DMTUYENs.ToList());
        }

        // GET: DmTuyen/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTUYEN dMTUYEN = db.DMTUYENs.Find(id);
            if (dMTUYEN == null)
            {
                return HttpNotFound();
            }
            return View(dMTUYEN);
        }

        // GET: DmTuyen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DmTuyen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTUYEN,MATUYEN,TENTUYENENG,TENTUYENVN,MATRAMDAU,MATRAMGIUA,MATRAMCUOI,TONGTRAM,MUCDO,THOIGIANTOANTRAM,GIAVE1,DIENGIAIVE1,CAMVE1,IDVE1IDHOADON,GIAVE2,DIENGIAIVE2,CAMVE2,IDVE2IDHOADON,GIAVE3,DIENGIAIVE3,CAMVE3,IDVE3IDHOADON,GIAVE4,DIENGIAIVE4,CAMVE4,IDVE4IDHOADON,GIAVE5,DIENGIAIVE5,CAMVE5,IDVE5IDHOADON,GIAVE6,DIENGIAIVE6,CAMVE6,IDVE6IDHOADON")] DMTUYEN dMTUYEN)
        {
            if (ModelState.IsValid)
            {
                db.DMTUYENs.Add(dMTUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMTUYEN);
        }

        // GET: DmTuyen/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTUYEN dMTUYEN = db.DMTUYENs.Find(id);
            if (dMTUYEN == null)
            {
                return HttpNotFound();
            }
            return View(dMTUYEN);
        }

        // POST: DmTuyen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTUYEN,MATUYEN,TENTUYENENG,TENTUYENVN,MATRAMDAU,MATRAMGIUA,MATRAMCUOI,TONGTRAM,MUCDO,THOIGIANTOANTRAM,GIAVE1,DIENGIAIVE1,CAMVE1,IDVE1IDHOADON,GIAVE2,DIENGIAIVE2,CAMVE2,IDVE2IDHOADON,GIAVE3,DIENGIAIVE3,CAMVE3,IDVE3IDHOADON,GIAVE4,DIENGIAIVE4,CAMVE4,IDVE4IDHOADON,GIAVE5,DIENGIAIVE5,CAMVE5,IDVE5IDHOADON,GIAVE6,DIENGIAIVE6,CAMVE6,IDVE6IDHOADON")] DMTUYEN dMTUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMTUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMTUYEN);
        }

        // GET: DmTuyen/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTUYEN dMTUYEN = db.DMTUYENs.Find(id);
            if (dMTUYEN == null)
            {
                return HttpNotFound();
            }
            return View(dMTUYEN);
        }

        // POST: DmTuyen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DMTUYEN dMTUYEN = db.DMTUYENs.Find(id);
            db.DMTUYENs.Remove(dMTUYEN);
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
