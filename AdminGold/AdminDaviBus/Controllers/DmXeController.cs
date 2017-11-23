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
    public class DmXeController : Controller
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: DmXe
        public ActionResult Index()
        {
            return View(db.DMXEs.ToList());
        }

        // GET: DmXe/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMXE dMXE = db.DMXEs.Find(id);
            if (dMXE == null)
            {
                return HttpNotFound();
            }
            return View(dMXE);
        }

        // GET: DmXe/Create
        public ActionResult Create()
        {
            var dataTaiXe = db.DMTAIXEs.ToList();
            dataTaiXe.Insert(0, new DMTAIXE { MATAIXE = "", TENTAIXE = "Chọn tài xế" });
            var model = new AllModel
            {
                DmXe = new DMXE(),
                ListDmTaiXe = dataTaiXe
            };
            return View(model);
        }

        // POST: DmXe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public ActionResult Create(DMXE dMXE)
        {
            if (ModelState.IsValid)
            {
                db.DMXEs.Add(dMXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMXE);
        }

        // GET: DmXe/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMXE dMXE = db.DMXEs.Find(id);
            if (dMXE == null)
            {
                return HttpNotFound();
            }
            var dataTaiXe = db.DMTAIXEs.ToList();
            dataTaiXe.Insert(0, new DMTAIXE { MATAIXE = "", TENTAIXE = "Chọn tài xế" });
            var model = new AllModel
            {
                DmXe = dMXE,
                ListDmTaiXe = dataTaiXe
            };
            return View(model);
        }

        // POST: DmXe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      
        public ActionResult Edit( DMXE dMXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMXE);
        }

        // GET: DmXe/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMXE dMXE = db.DMXEs.Find(id);
            db.DMXEs.Remove(dMXE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: DmXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DMXE dMXE = db.DMXEs.Find(id);
            db.DMXEs.Remove(dMXE);
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
