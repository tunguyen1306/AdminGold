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
    public class ProductsController : Controller
    {
        private AdminGoldEntities db = new AdminGoldEntities();

        // GET: Products
        public ActionResult Index()
        {
            var qrData =( from dataPro in db.tbl_products_tra
                         join dataImg in db.tblSysPictures on dataPro.id_products_tra equals dataImg.advert_id
                         where dataImg.position==1
                          select new ProductsPicture {tblProducts=dataPro,clPicture=dataImg });

           
            return View(qrData.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_products_tra tbl_products_tra = db.tbl_products_tra.Find(id);
            if (tbl_products_tra == null)
            {
                return HttpNotFound();
            }
            return View(tbl_products_tra);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_products_tra,img_products_tra,img1_products_tra,img2_products_tra,img3_products_tra,name_products_tra,code_products_tra,des_products_tra,status_products_tra,newprice_products_tra,oldprice_products_tra")] tbl_products_tra tbl_products_tra)
        {
            if (ModelState.IsValid)
            {
                db.tbl_products_tra.Add(tbl_products_tra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_products_tra);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            


            ProductsPicture pic = new ProductsPicture { tblProducts = db.tbl_products_tra.Find(id),classPicture = db.tblSysPictures.Where(t=>t.advert_id== id).ToList() };


            return View(pic);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ProductsPicture item)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(item.tblProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_products_tra tbl_products_tra = db.tbl_products_tra.Find(id);
            if (tbl_products_tra == null)
            {
                return HttpNotFound();
            }
            return View(tbl_products_tra);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_products_tra tbl_products_tra = db.tbl_products_tra.Find(id);
            db.tbl_products_tra.Remove(tbl_products_tra);
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
