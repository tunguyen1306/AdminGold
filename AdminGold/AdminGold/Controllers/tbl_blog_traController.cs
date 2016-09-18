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
    public class tbl_blog_traController : Controller
    {
        private AdminGoldEntities db = new AdminGoldEntities();

        // GET: tbl_blog_tra
        public ActionResult Index()
        {
            return View(db.tbl_blog_tra.ToList());
        }

        // GET: tbl_blog_tra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_blog_tra tbl_blog_tra = db.tbl_blog_tra.Find(id);
            if (tbl_blog_tra == null)
            {
                return HttpNotFound();
            }
            return View(tbl_blog_tra);
        }

        // GET: tbl_blog_tra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_blog_tra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_blog_tra,titile_blog_tra,short_des_blog_tra,des_blog_tra,status_blog_tra,type_blog_tra,create_date_blog_tra")] tbl_blog_tra tbl_blog_tra)
        {
            if (ModelState.IsValid)
            {
                db.tbl_blog_tra.Add(tbl_blog_tra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_blog_tra);
        }

        // GET: tbl_blog_tra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_blog_tra tbl_blog_tra = db.tbl_blog_tra.Find(id);
            if (tbl_blog_tra == null)
            {
                return HttpNotFound();
            }
            return View(tbl_blog_tra);
        }

        // POST: tbl_blog_tra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_blog_tra,titile_blog_tra,short_des_blog_tra,des_blog_tra,status_blog_tra,type_blog_tra,create_date_blog_tra")] tbl_blog_tra tbl_blog_tra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_blog_tra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_blog_tra);
        }

        // GET: tbl_blog_tra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_blog_tra tbl_blog_tra = db.tbl_blog_tra.Find(id);
            if (tbl_blog_tra == null)
            {
                return HttpNotFound();
            }
            return View(tbl_blog_tra);
        }

        // POST: tbl_blog_tra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_blog_tra tbl_blog_tra = db.tbl_blog_tra.Find(id);
            db.tbl_blog_tra.Remove(tbl_blog_tra);
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
