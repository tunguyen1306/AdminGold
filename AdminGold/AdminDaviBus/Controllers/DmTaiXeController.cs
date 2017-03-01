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
    public class DmTaiXeController : Controller
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: DmTaiXe
        public ActionResult Index()
        {
            return View(db.DMTAIXEs.ToList());
        }

        // GET: DmTaiXe/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTAIXE dMTAIXE = db.DMTAIXEs.Find(id);
            if (dMTAIXE == null)
            {
                return HttpNotFound();
            }
            return View(dMTAIXE);
        }

        // GET: DmTaiXe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DmTaiXe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATAIXE,TENTAIXE,TUOI,GIOITINH,BANGLAI,SDT,DIACHINOIO,EMAIL")] DMTAIXE dMTAIXE)
        {
            if (ModelState.IsValid)
            {
                db.DMTAIXEs.Add(dMTAIXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMTAIXE);
        }

        // GET: DmTaiXe/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTAIXE dMTAIXE = db.DMTAIXEs.Find(id);
            if (dMTAIXE == null)
            {
                return HttpNotFound();
            }
            return View(dMTAIXE);
        }

        // POST: DmTaiXe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATAIXE,TENTAIXE,TUOI,GIOITINH,BANGLAI,SDT,DIACHINOIO,EMAIL")] DMTAIXE dMTAIXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMTAIXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMTAIXE);
        }

        // GET: DmTaiXe/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTAIXE dMTAIXE = db.DMTAIXEs.Find(id);
            if (dMTAIXE == null)
            {
                return HttpNotFound();
            }
            return View(dMTAIXE);
        }

        // POST: DmTaiXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DMTAIXE dMTAIXE = db.DMTAIXEs.Find(id);
            db.DMTAIXEs.Remove(dMTAIXE);
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
