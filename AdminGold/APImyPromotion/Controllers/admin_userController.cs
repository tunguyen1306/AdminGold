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
    public class admin_userController : Controller
    {
        private MyPromotionEntities db = new MyPromotionEntities();

        // GET: admin_user
        public ActionResult Index()
        {
            return View(db.tbl_user_promotion.ToList());
        }

        // GET: admin_user/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user_promotion tbl_user_promotion = db.tbl_user_promotion.Find(id);
            if (tbl_user_promotion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user_promotion);
        }

        // GET: admin_user/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin_user/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_user_promotion,email_user_promotion,phone_user_promotion,first_name_user_promotion,last_name_user_promotion,type_role_user_promotion,status_user_promotion,pass_user_promotion,img_user_promotion,full_name_user_promotion")] tbl_user_promotion tbl_user_promotion)
        {
            if (ModelState.IsValid)
            {
                db.tbl_user_promotion.Add(tbl_user_promotion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_user_promotion);
        }

        // GET: admin_user/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user_promotion tbl_user_promotion = db.tbl_user_promotion.Find(id);
            if (tbl_user_promotion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user_promotion);
        }

        // POST: admin_user/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_user_promotion,email_user_promotion,phone_user_promotion,first_name_user_promotion,last_name_user_promotion,type_role_user_promotion,status_user_promotion,pass_user_promotion,img_user_promotion,full_name_user_promotion")] tbl_user_promotion tbl_user_promotion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_user_promotion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_user_promotion);
        }

        // GET: admin_user/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user_promotion tbl_user_promotion = db.tbl_user_promotion.Find(id);
            if (tbl_user_promotion == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user_promotion);
        }

        // POST: admin_user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_user_promotion tbl_user_promotion = db.tbl_user_promotion.Find(id);
            db.tbl_user_promotion.Remove(tbl_user_promotion);
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
