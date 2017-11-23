﻿using System;
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
    public class DmHoaDonController : Controller
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: DmHoaDon
        public ActionResult Index()
        {
            return View(db.DMHOADONs.ToList());
        }

        // GET: DmHoaDon/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMHOADON dMHOADON = db.DMHOADONs.Find(id);
            if (dMHOADON == null)
            {
                return HttpNotFound();
            }
            return View(dMHOADON);
        }

        // GET: DmHoaDon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DmHoaDon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create( DMHOADON dMHOADON)
        {
            if (ModelState.IsValid)
            {
                dMHOADON.IDVE = 1;
                db.DMHOADONs.Add(dMHOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMHOADON);
        }

        // GET: DmHoaDon/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMHOADON dMHOADON = db.DMHOADONs.Find(id);
            if (dMHOADON == null)
            {
                return HttpNotFound();
            }
            return View(dMHOADON);
        }

        // POST: DmHoaDon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
  
        public ActionResult Edit( DMHOADON dMHOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMHOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMHOADON);
        }

        // GET: DmHoaDon/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMHOADON dMHOADON = db.DMHOADONs.Find(id);
            if (dMHOADON == null)
            {
                return HttpNotFound();
            }
            return View(dMHOADON);
        }

        // POST: DmHoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DMHOADON dMHOADON = db.DMHOADONs.Find(id);
            db.DMHOADONs.Remove(dMHOADON);
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
