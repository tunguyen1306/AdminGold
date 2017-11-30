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
        private VanGiaEntities db1 = new VanGiaEntities();
  private AdminGoldEntities db = new AdminGoldEntities();
        // GET: AdminSlider
        public ActionResult Index()
        {
            return View(db.web_vangia_silde.Where(x=>x.company==1).ToList());
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
            
            if (ModelState.IsValid)
            {
                db.web_vangia_silde.Add(web_vangia_silde);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(web_vangia_silde);
        }
        [HttpPost]
        public ActionResult UploadImg( web_vangia_silde web_vangia_silde)
        {
            var t = web_vangia_silde.vangia_img_silde == null ? "" : web_vangia_silde.vangia_img_silde;
            var file = t.Replace("data:image/png;base64,", "");
            if (!String.IsNullOrEmpty(file))
            {
                var photoBytes = Convert.FromBase64String(file);
                string format = "jpg";


                var settings = new ResizeSettings();
                settings.Scale = ScaleMode.DownscaleOnly;
                settings.Format = format;

                //string uploadFolder = picture.DirectoryPhysical;

                string path = Server.MapPath("~/fileUpload/") + DateTime.Now.Day + DateTime.Now.Month + "/";
                // check for directory
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var picture = new VanGiaPicture
                {
                    tblPicture = new tblSysPicture { advert_id = 0, angleType = 0, cms_sql_id = 0, converted = DateTime.Now, tocheck = true, type_id = 1, title = "", position = 1 }
                };
                if (picture.GetConvertedFileName() == null || string.IsNullOrWhiteSpace(picture.GetConvertedFileName()))
                    picture.SetFileName(DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + "_" + picture.CreateFilename() + "_{0}." + format);

                if (picture.GetFilePathPhysical(VanGiaPicture.PictureSize.Large) != null)
                {
                    string dest = path + picture.FileName(VanGiaPicture.PictureSize.Large);
                    settings.MaxWidth = 1920;
                    settings.MaxHeight = 1200;
                    if (picture.WaterMarkLarge == VanGiaPicture.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    web_vangia_silde.vangia_img_silde = picture.GetFilePath(VanGiaPicture.PictureSize.Large);
                }
                if (picture.GetFilePathPhysical(VanGiaPicture.PictureSize.Medium) != null)
                {
                    string dest = path + picture.FileName(VanGiaPicture.PictureSize.Medium);
                    settings.MaxWidth = 130;
                    settings.MaxHeight = 130;
                    if (picture.WaterMarkLarge == VanGiaPicture.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                }
                return Json(new { result = web_vangia_silde.vangia_img_silde });

            }
            else
            {
                var data = db.web_vangia_silde.Where(x => x.vangia_id_silde == web_vangia_silde.vangia_id_silde).FirstOrDefault();
                return Json(new { result = data.vangia_img_silde });
            }

            
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
        public ActionResult Edit( web_vangia_silde web_vangia_silde)
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
            web_vangia_silde web_vangia_silde = db.web_vangia_silde.Find(id);
            db.web_vangia_silde.Remove(web_vangia_silde);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: AdminSlider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
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
