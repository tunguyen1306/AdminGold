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
    public class DmTramController : Controller
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: DmTram
        public ActionResult Index()
        {
            return View(db.DMTRAMs.ToList());
        }
        [HttpPost]
        public ActionResult GetTram(string Id)
        {
            
            var listTram = new List<DMTRAM>();
           
            var dataListTram = db.DMTUYENCHITIETTRAMs.Where(x => x.IDTUYEN == db.DMTUYENs.FirstOrDefault(y => y.IDTUYEN == Id).MATUYEN).ToList();
            var tram = db.DMTRAMs.ToList();
            foreach (var item in dataListTram)
            {
                var listT = new DMTRAM();
                listT.MATRAM = item.MATRAM;
                listT.TENTRAM = db.DMTRAMs.FirstOrDefault(x => x.MATRAM== item.MATRAM).TENTRAM;
                listT.LatLng = db.DMTRAMs.FirstOrDefault(x => x.MATRAM== item.MATRAM).LatLng;
                listTram.Add(listT);
            }
            
            var dataAll = new AllModel
            {
                TblDMTUYEN = db.DMTUYENs.FirstOrDefault(x => x.IDTUYEN == Id),
                ListDMTUYENCHITIETTRAM = db.DMTUYENCHITIETTRAMs.Where(x=>x.IDTUYEN== db.DMTUYENs.FirstOrDefault(y => y.IDTUYEN == Id).MATUYEN).ToList(),
                ListDMTRAM = listTram
            };
            return Json(new {result= dataAll });
        }
        // GET: DmTram/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTRAM dMTRAM = db.DMTRAMs.Find(id);
            if (dMTRAM == null)
            {
                return HttpNotFound();
            }
            return View(dMTRAM);
        }

        // GET: DmTram/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DmTram/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public ActionResult Create(DMTRAM dMTRAM)
        {
          
                db.DMTRAMs.Add(dMTRAM);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }

        // GET: DmTram/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTRAM dMTRAM = db.DMTRAMs.Find(id);
            if (dMTRAM == null)
            {
                return HttpNotFound();
            }
            return View(dMTRAM);
        }

        // POST: DmTram/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public ActionResult Edit( DMTRAM dMTRAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMTRAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMTRAM);
        }

        // GET: DmTram/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTRAM dMTRAM = db.DMTRAMs.Find(id);
            db.DMTRAMs.Remove(dMTRAM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: DmTram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DMTRAM dMTRAM = db.DMTRAMs.Find(id);
            db.DMTRAMs.Remove(dMTRAM);
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
