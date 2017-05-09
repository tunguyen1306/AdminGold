using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminGold.Models;
using ImageResizer;
using System.IO;

namespace AdminGold.Controllers
{
    public class AdminSliderController : Controller
    {
        private VanGiaEntities db = new VanGiaEntities();

        // GET: AdminSlider
        public ActionResult Index()
        {
            return View(db.web_vangia_silde.ToList());
        }

        // GET: AdminSlider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            web_vangia_silde web_vangia_silde = db.web_vangia_silde.Find(id);
            if (web_vangia_silde == null)
            {
                return HttpNotFound();
            }
            return View(web_vangia_silde);
        }

        // GET: AdminSlider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminSlider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( web_vangia_silde web_vangia_silde)
        {
            var t = projectPicture.cfile == null ? "" : projectPicture.cfile;
            var file = t.Replace("data:image/png;base64,", "");
            var photoBytes = Convert.FromBase64String(file);
            string format = "jpg";
            var picture = new VanGiaPicture
            {
                tblPicture = new tblSysPicture { advert_id = projectPicture.idProducts,
                    angleType = 0, cms_sql_id = 0, converted = DateTime.Now, tocheck = true, type_id = 1,
                    title = projectPicture.nameImg, position = projectPicture.isactive }
            };

            var settings = new ResizeSettings();
            settings.Scale = ScaleMode.DownscaleOnly;
            settings.Format = format;

            //string uploadFolder = picture.DirectoryPhysical;

            string path = Server.MapPath("~/fileUpload/") + DateTime.Now.Day + DateTime.Now.Month + "/";
            // check for directory
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // filename with placeholder for size
            if (picture.GetConvertedFileName() == null || string.IsNullOrWhiteSpace(picture.GetConvertedFileName()))
                picture.SetFileName(DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + "_" + picture.CreateFilename() + "_{0}." + format);

            if (picture.GetFilePathPhysical(VanGiaPicture.PictureSize.Large) != null)
            {
                string dest = path + picture.FileName(VanGiaPicture.PictureSize.Large);
                settings.MaxWidth = 720;
                settings.MaxHeight = 480;
                if (picture.WaterMarkLarge == VanGiaPicture.WatermarkType.None)
                    ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                // save biggest version as original
                if (string.IsNullOrWhiteSpace(picture.tblPicture.originalFilepath))
                    picture.tblPicture.originalFilepath = picture.GetFilePath(VanGiaPicture.PictureSize.Large);
            }
            if (ModelState.IsValid)
            {
                db.web_vangia_silde.Add(web_vangia_silde);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(web_vangia_silde);
        }

        // GET: AdminSlider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            web_vangia_silde web_vangia_silde = db.web_vangia_silde.Find(id);
            if (web_vangia_silde == null)
            {
                return HttpNotFound();
            }
            return View(web_vangia_silde);
        }

        // POST: AdminSlider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vangia_id_silde,vangia_noidung_silde,vangia_tomtat_silde,vangia_img_silde,vangia_name_silde,vangia_status_silde,vangia_order_silde,vangia_language_silde,vangia_link_silde,vangia_stype_slide,vangia_type_slide")] web_vangia_silde web_vangia_silde)
        {
            if (ModelState.IsValid)
            {
                db.Entry(web_vangia_silde).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(web_vangia_silde);
        }

        // GET: AdminSlider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            web_vangia_silde web_vangia_silde = db.web_vangia_silde.Find(id);
            if (web_vangia_silde == null)
            {
                return HttpNotFound();
            }
            return View(web_vangia_silde);
        }

        // POST: AdminSlider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            web_vangia_silde web_vangia_silde = db.web_vangia_silde.Find(id);
            db.web_vangia_silde.Remove(web_vangia_silde);
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
