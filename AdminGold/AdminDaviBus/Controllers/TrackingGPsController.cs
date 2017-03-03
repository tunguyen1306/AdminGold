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
    public class TrackingGPsController : Controller
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: TrackingGPs
        public ActionResult Index()
        {
            return View(db.TrackingGPS.ToList());
        }

        // GET: TrackingGPs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackingGP trackingGP = db.TrackingGPS.Find(id);
            if (trackingGP == null)
            {
                return HttpNotFound();
            }
            return View(trackingGP);
        }

        // GET: TrackingGPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackingGPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTracking,MaXe,MaTuyen,Time,DeviceId,Lat,lng")] TrackingGP trackingGP)
        {
            if (ModelState.IsValid)
            {
                db.TrackingGPS.Add(trackingGP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trackingGP);
        }

        // GET: TrackingGPs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackingGP trackingGP = db.TrackingGPS.Find(id);
            if (trackingGP == null)
            {
                return HttpNotFound();
            }
            return View(trackingGP);
        }

        // POST: TrackingGPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTracking,MaXe,MaTuyen,Time,DeviceId,Lat,lng")] TrackingGP trackingGP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trackingGP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trackingGP);
        }

        // GET: TrackingGPs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackingGP trackingGP = db.TrackingGPS.Find(id);
            if (trackingGP == null)
            {
                return HttpNotFound();
            }
            return View(trackingGP);
        }

        // POST: TrackingGPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TrackingGP trackingGP = db.TrackingGPS.Find(id);
            db.TrackingGPS.Remove(trackingGP);
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
