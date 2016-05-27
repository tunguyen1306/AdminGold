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
    public class VanGiaController : Controller
    {
        private VanGiaEntities db = new VanGiaEntities();

        // GET: VanGia
        public ActionResult Index()
        {
            var qrData = (from dataPro in db.web_vangia_project
                          join dataImg in db.tblSysPictures on dataPro.vangia_id_project equals dataImg.advert_id
                          where dataImg.position == 1
                          select new VanGiaPicture { tblProject = dataPro, tblPicture = dataImg });
            return View(qrData.ToList());
        }

        // GET: VanGia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            web_vangia_project web_vangia_project = db.web_vangia_project.Find(id);
            if (web_vangia_project == null)
            {
                return HttpNotFound();
            }
            return View(web_vangia_project);
        }

        // GET: VanGia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VanGia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vangia_id_project,vangia_img1_project,vangia_img2_project,vangia_img3_project,vangia_img_project,vangia_content_project,vangia_name_project,vangia_time_project,vangia_status_project,vangia_order_project,vangia_language_project,vangia_tomtat_project,vangia_typeid_project,vangia_img4_project,vangia_img5_project,vangia_img6_project,vangia_img7_project,vangia_img8_project,vangia_img9_project,vangia_vanban_project")] web_vangia_project web_vangia_project)
        {
            if (ModelState.IsValid)
            {
                db.web_vangia_project.Add(web_vangia_project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(web_vangia_project);
        }

        // GET: VanGia/Edit/5
        public ActionResult Edit(int? id)
        {
            VanGiaPicture pic = new VanGiaPicture { tblProject = db.web_vangia_project.Find(id), tblListPicture = db.tblSysPictures.Where(t => t.advert_id == id).ToList() };


            return View(pic);
        }

        // POST: VanGia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VanGiaPicture web_vangia_project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(web_vangia_project.tblProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(web_vangia_project);
        }

        // GET: VanGia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            web_vangia_project web_vangia_project = db.web_vangia_project.Find(id);
            db.web_vangia_project.Remove(web_vangia_project);
            db.SaveChanges();
            return RedirectToAction("Index","VanGia");
        }

        // POST: VanGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            web_vangia_project web_vangia_project = db.web_vangia_project.Find(id);
            db.web_vangia_project.Remove(web_vangia_project);
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
        public ActionResult CreateFirst(web_vangia_project tbl_project)
        {
            if (ModelState.IsValid)
            {
                db.web_vangia_project.Add(tbl_project);
                db.SaveChanges();


            }
            return View(tbl_project);

        }

        [HttpPost]

        public void SaveImg(VanGiaPicture projectPicture)
        {
            var t = projectPicture.cfile == null ? "" : projectPicture.cfile;
            var file = t.Replace("data:image/png;base64,", "");
            var photoBytes = Convert.FromBase64String(file);
            string format = "jpg";
            if (projectPicture.isactive == 1)
            {
                projectPicture.isactive = 1;
            }
            else
            {
                projectPicture.isactive = 2;
            }
            var picture = new VanGiaPicture
            {
                tblPicture = new tblSysPicture { advert_id = projectPicture.idProducts, angleType = 0, cms_sql_id = 0, converted = DateTime.Now, tocheck = true, type_id = 1, title = projectPicture.nameImg, position = projectPicture.isactive }
            };
            if (projectPicture.idpicture == 0)
            {
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
                    settings.MaxWidth = 800;
                    settings.MaxHeight = 800;
                    if (picture.WaterMarkLarge == VanGiaPicture.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.tblPicture.originalFilepath))
                        picture.tblPicture.originalFilepath = picture.GetFilePath(VanGiaPicture.PictureSize.Large);
                }

                if (picture.GetFilePathPhysical(VanGiaPicture.PictureSize.Medium) != null)
                {
                    string dest = path + picture.FileName(VanGiaPicture.PictureSize.Medium);
                    settings.MaxWidth = 300;
                    settings.MaxHeight = 300;
                    if (picture.WaterMarkLarge == VanGiaPicture.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.tblPicture.originalFilepath))
                        picture.tblPicture.originalFilepath = picture.GetFilePath(VanGiaPicture.PictureSize.Medium);
                }


                db.tblSysPictures.Add(picture.tblPicture);
                db.SaveChanges();
            }
            if (projectPicture.idpicture > 0)
            {

                tblSysPicture tblpict = db.tblSysPictures.Find(projectPicture.idpicture);
                tblpict.title = projectPicture.nameImg;
                tblpict.position = projectPicture.isactive;
                db.Entry(tblpict).State = EntityState.Modified;
                db.SaveChanges();
                RedirectToAction("Index", "VanGia");
            }


        }

        [HttpPost]
        public ActionResult CreateFirst(VanGiaPicture projectPicture)
        {
            web_vangia_project tblproduct = projectPicture.tblProject;

            db.Entry(tblproduct).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "VanGia");



        }
        [HttpPost]
        public ActionResult DeleteImg(int idpicture)
        {
            tblSysPicture tblPic = db.tblSysPictures.Find(idpicture);
            db.tblSysPictures.Remove(tblPic);
            db.SaveChanges();
            return View(tblPic);
        }
        [HttpPost]
        public ActionResult Cancel(int id)
        {
            web_vangia_project tblproduct = db.web_vangia_project.Find(id);
            db.web_vangia_project.Remove(tblproduct);
            db.SaveChanges();
            return RedirectToAction("Index", "VanGia");



        }
    }
}
