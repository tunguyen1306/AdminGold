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
    public class DichVuController : Controller
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: DichVu
        public ActionResult Index()
        {
            return View(db.DICHVUs.ToList());
        }

        // GET: DichVu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DICHVU dICHVU = db.DICHVUs.Find(id);
            if (dICHVU == null)
            {
                return HttpNotFound();
            }
            return View(dICHVU);
        }

        // GET: DichVu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DichVu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NGAY,SQMS,GIOLAYSO,dichvu1,GIAVE,MATUYEN,TENTUYEN,MATRAMDAU,MATRAMCUOI,LOTRINH,BienSoXe,TRANGTHAI,PHUCVU,GHICHU,Contro,Doc,DATCHO,GIO_GOC,BINH_CHON,GIO_BINHCHON,NGONNGU,DIEMGIAODICH,MANV,QUAYCHUYEN,QUAYTHAMCHIEU,SODIENTHOAI,QUAY,GIOPHUCVU,MAXE,MATAIXE,MATRAM,IDTUYEN,KYHIEUVE,MAUSO,MATRAMGIUA")] DICHVU dICHVU)
        {
            if (ModelState.IsValid)
            {
                db.DICHVUs.Add(dICHVU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dICHVU);
        }

        // GET: DichVu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DICHVU dICHVU = db.DICHVUs.Find(id);
            if (dICHVU == null)
            {
                return HttpNotFound();
            }
            return View(dICHVU);
        }

        // POST: DichVu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NGAY,SQMS,GIOLAYSO,dichvu1,GIAVE,MATUYEN,TENTUYEN,MATRAMDAU,MATRAMCUOI,LOTRINH,BienSoXe,TRANGTHAI,PHUCVU,GHICHU,Contro,Doc,DATCHO,GIO_GOC,BINH_CHON,GIO_BINHCHON,NGONNGU,DIEMGIAODICH,MANV,QUAYCHUYEN,QUAYTHAMCHIEU,SODIENTHOAI,QUAY,GIOPHUCVU,MAXE,MATAIXE,MATRAM,IDTUYEN,KYHIEUVE,MAUSO,MATRAMGIUA")] DICHVU dICHVU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dICHVU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dICHVU);
        }

        // GET: DichVu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DICHVU dICHVU = db.DICHVUs.Find(id);
            if (dICHVU == null)
            {
                return HttpNotFound();
            }
            return View(dICHVU);
        }

        // POST: DichVu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DICHVU dICHVU = db.DICHVUs.Find(id);
            db.DICHVUs.Remove(dICHVU);
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
