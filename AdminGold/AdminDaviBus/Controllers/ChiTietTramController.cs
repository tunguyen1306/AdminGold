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
    public class ChiTietTramController : Controller
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: ChiTietTram
        public ActionResult Index()
        {
            return View(db.DMTUYENCHITIETTRAMs.ToList());
        }

        // GET: ChiTietTram/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM = db.DMTUYENCHITIETTRAMs.Find(id);
            if (dMTUYENCHITIETTRAM == null)
            {
                return HttpNotFound();
            }
            return View(dMTUYENCHITIETTRAM);
        }

        // GET: ChiTietTram/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiTietTram/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDTUYEN,MATRAM,TRAMDAU,TRAMCUOI")] DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM)
        {
            if (ModelState.IsValid)
            {
                db.DMTUYENCHITIETTRAMs.Add(dMTUYENCHITIETTRAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMTUYENCHITIETTRAM);
        }

        // GET: ChiTietTram/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM = db.DMTUYENCHITIETTRAMs.Find(id);
            if (dMTUYENCHITIETTRAM == null)
            {
                return HttpNotFound();
            }
            return View(dMTUYENCHITIETTRAM);
        }

        // POST: ChiTietTram/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDTUYEN,MATRAM,TRAMDAU,TRAMCUOI")] DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMTUYENCHITIETTRAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMTUYENCHITIETTRAM);
        }

        // GET: ChiTietTram/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM = db.DMTUYENCHITIETTRAMs.Find(id);
            if (dMTUYENCHITIETTRAM == null)
            {
                return HttpNotFound();
            }
            return View(dMTUYENCHITIETTRAM);
        }

        // POST: ChiTietTram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM = db.DMTUYENCHITIETTRAMs.Find(id);
            db.DMTUYENCHITIETTRAMs.Remove(dMTUYENCHITIETTRAM);
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
