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
    public class LoTrinhChoXeController : Controller
    {
        private BusTicketEntities db = new BusTicketEntities();

        // GET: LoTrinhChoXe
        public ActionResult Index()
        {
            return View(db.LOTRINHCHOXEs.ToList());
        }

        // GET: LoTrinhChoXe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTRINHCHOXE lOTRINHCHOXE = db.LOTRINHCHOXEs.Find(id);
            if (lOTRINHCHOXE == null)
            {
                return HttpNotFound();
            }
            return View(lOTRINHCHOXE);
        }

        // GET: LoTrinhChoXe/Create
        public ActionResult Create()
        {
            var all = new AllModel
            {
               ListDmXe = db.DMXEs.ToList(),
               ListDMTUYEN = db.DMTUYENs.ToList(),
               ListDmTaiXe = db.DMTAIXEs.ToList(),
              
            };
            return View(all);
        }

        // POST: LoTrinhChoXe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      
        public ActionResult Create( AllModel lOTRINHCHOXE)
        {
           
                db.LOTRINHCHOXEs.Add(lOTRINHCHOXE.TblLoTrinhXe);
                db.SaveChanges();
                return RedirectToAction("Index");
           

            
        }

        // GET: LoTrinhChoXe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTRINHCHOXE lOTRINHCHOXE = db.LOTRINHCHOXEs.Find(id);
            if (lOTRINHCHOXE == null)
            {
                return HttpNotFound();
            }
            var all = new AllModel
            {
                ListDmXe = db.DMXEs.ToList(),
                ListDMTUYEN = db.DMTUYENs.ToList(),
                ListDmTaiXe = db.DMTAIXEs.ToList(),
                TblLoTrinhXe = lOTRINHCHOXE,
                Cam = lOTRINHCHOXE.CAM==true ?"1":"0",
                KichHoat = lOTRINHCHOXE.KICHHOAT==true ?"1":"0",

            };
            return View(all);
        }

        // POST: LoTrinhChoXe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
     
        public ActionResult Edit(AllModel lOtrinhchoxe)
        {
            var tblLotrinh = new LOTRINHCHOXE();
            tblLotrinh.CAM = lOtrinhchoxe.Cam=="0" ? false :true;
            tblLotrinh.KICHHOAT =lOtrinhchoxe.KichHoat == "0" ? false : true ;
            tblLotrinh.IDTUYEN = lOtrinhchoxe.TblLoTrinhXe.IDTUYEN;
            tblLotrinh.MATAIXE = lOtrinhchoxe.TblLoTrinhXe.MATAIXE;
            tblLotrinh.MAXE = lOtrinhchoxe.TblLoTrinhXe.MAXE;
            tblLotrinh.IDLOTRINH = lOtrinhchoxe.TblLoTrinhXe.IDLOTRINH;
          

                db.Entry(tblLotrinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
   
        }

        // GET: LoTrinhChoXe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTRINHCHOXE lOTRINHCHOXE = db.LOTRINHCHOXEs.Find(id);
            if (lOTRINHCHOXE == null)
            {
                return HttpNotFound();
            }
            return View(lOTRINHCHOXE);
        }

        // POST: LoTrinhChoXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOTRINHCHOXE lOTRINHCHOXE = db.LOTRINHCHOXEs.Find(id);
            db.LOTRINHCHOXEs.Remove(lOTRINHCHOXE);
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
