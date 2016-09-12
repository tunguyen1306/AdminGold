using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APImyPromotion.Models;

namespace APImyPromotion.Controllers
{
    public class SlidePromotionController : Controller
    {
        private MyPromotionEntities db = new MyPromotionEntities();

        // GET: SlidePromotion
        public ActionResult Index()
        {
            return View(db.tbl_slide_promotion.ToList());
        }

        // GET: SlidePromotion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_slide_promotion tbl_slide_promotion = db.tbl_slide_promotion.Find(id);
            if (tbl_slide_promotion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_slide_promotion);
        }

        // GET: SlidePromotion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlidePromotion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_slide,img_slide,title_slide,des_slide,status_slide")] tbl_slide_promotion tbl_slide_promotion)
        {
            if (ModelState.IsValid)
            {
                db.tbl_slide_promotion.Add(tbl_slide_promotion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_slide_promotion);
        }

        // GET: SlidePromotion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_slide_promotion tbl_slide_promotion = db.tbl_slide_promotion.Find(id);
            if (tbl_slide_promotion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_slide_promotion);
        }

        // POST: SlidePromotion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_slide,img_slide,title_slide,des_slide,status_slide")] tbl_slide_promotion tbl_slide_promotion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_slide_promotion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_slide_promotion);
        }

        // GET: SlidePromotion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_slide_promotion tbl_slide_promotion = db.tbl_slide_promotion.Find(id);
            if (tbl_slide_promotion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_slide_promotion);
        }

        // POST: SlidePromotion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_slide_promotion tbl_slide_promotion = db.tbl_slide_promotion.Find(id);
            db.tbl_slide_promotion.Remove(tbl_slide_promotion);
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
