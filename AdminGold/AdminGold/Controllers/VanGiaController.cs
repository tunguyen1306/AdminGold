﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AdminGold.Models;
using ImageResizer;
using System.IO;


namespace AdminGold.Controllers
{
    public class VanGiaController : Controller
    {
        private VanGiaEntities db1 = new VanGiaEntities();
        private AdminGoldEntities db = new AdminGoldEntities();
        // GET: VanGia
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session["user"].ToString() != "vangia.net@gmail.com")
            {
                return RedirectToAction("Login", "Home");
            }
            var qrData = (from dataPro in db.web_vangia_project
                          where dataPro.vangia_status_project !=null  && dataPro.company==1
                          select new VanGiaPicture { tblProject = dataPro});
            return View(qrData.ToList());
        }

        // GET: VanGia/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
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
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        // POST: VanGia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create( web_vangia_project web_vangia_project)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.web_vangia_project.Add(web_vangia_project);
                db.SaveChanges();
                return RedirectToAction("Index", "VanGia");
            }

            return View(web_vangia_project);
        }

        // GET: VanGia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            VanGiaPicture pic = new VanGiaPicture { tblProject = db.web_vangia_project.Find(id), tblListPicture = db.tblSysPictures.Where(t => t.advert_id == id).ToList() };


            return View(pic);
        }

        // POST: VanGia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(VanGiaPicture web_vangia_project)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file1 = Request.Files[0];

                    if (file1 != null && file1.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + "_" + web_vangia_project.CreateFilename() + "_" + file1.FileName);
                        var path = Path.Combine(Server.MapPath("~/fileUpload/" + DateTime.Now.Day + DateTime.Now.Month + "/"), fileName);


                        file1.SaveAs(path);
                        web_vangia_project.tblProject.vangia_vanban_project = fileName;
                    }

                }

                db.Entry(web_vangia_project.tblProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "VanGia");
            }
            return View(web_vangia_project);
        }

        // GET: VanGia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            web_vangia_project web_vangia_project = db.web_vangia_project.Find(id);
            VanGiaPicture vgpic = new VanGiaPicture();
            List<tblSysPicture> list = (from t in db.tblSysPictures where t.advert_id==id select t).ToList();
            foreach (tblSysPicture item in list)
            {
                db.tblSysPictures.Remove(item);
            }
            db.SaveChanges();
            db.web_vangia_project.Remove(web_vangia_project);
            db.SaveChanges();
            return RedirectToAction("Index", "VanGia");
        }

        // POST: VanGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
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
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
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
                    settings.MaxWidth = 1920;
                    settings.MaxHeight = 1200;
                    if (picture.WaterMarkLarge == VanGiaPicture.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.tblPicture.originalFilepath))
                        picture.tblPicture.originalFilepath = picture.GetFilePath(VanGiaPicture.PictureSize.Large);
                }

                if (picture.GetFilePathPhysical(VanGiaPicture.PictureSize.Medium) != null)
                {
                    string dest = path + picture.FileName(VanGiaPicture.PictureSize.Medium);
                    settings.MaxWidth = 130;
                    settings.MaxHeight = 130;
                    if (picture.WaterMarkLarge == VanGiaPicture.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.tblPicture.originalFilepath))
                        picture.tblPicture.originalFilepath = picture.GetFilePath(VanGiaPicture.PictureSize.Medium);
                }
 if (picture.GetFilePathPhysical(VanGiaPicture.PictureSize.Tiny) != null)
                {
                    string dest = path + picture.FileName(VanGiaPicture.PictureSize.Tiny);
                    settings.MaxWidth = 1500;
                    settings.MaxHeight = 600;
                    if (picture.WaterMarkLarge == VanGiaPicture.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.tblPicture.originalFilepath))
                        picture.tblPicture.originalFilepath = picture.GetFilePath(VanGiaPicture.PictureSize.Tiny);
                }

                if (picture.GetFilePathPhysical(VanGiaPicture.PictureSize.Small) != null)
                {
                    string dest = path + picture.FileName(VanGiaPicture.PictureSize.Small);
                    settings.MaxWidth = 600;
                    settings.MaxHeight = 300;
                    if (picture.WaterMarkLarge == VanGiaPicture.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.tblPicture.originalFilepath))
                        picture.tblPicture.originalFilepath = picture.GetFilePath(VanGiaPicture.PictureSize.Small);
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
            if (Request.Files.Count > 0)
            {
                var file1 = Request.Files[0];

                if (file1 != null && file1.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + "_" + projectPicture.CreateFilename() + "_" + file1.FileName);
                    var path = Path.Combine(Server.MapPath("~/fileUpload/" + DateTime.Now.Day + DateTime.Now.Month + "/"), fileName);


                    file1.SaveAs(path);
                    tblproduct.vangia_vanban_project = fileName;
                }

            }


            db.Entry(tblproduct).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "VanGia");



        }
        [HttpPost]
        public ActionResult DeleteImg(int idpicture)
        {
            tblSysPicture tblPic = db.tblSysPictures.Find(idpicture);
            VanGiaPicture vgPic = new VanGiaPicture();
            vgPic.tblPicture = tblPic;
            db.tblSysPictures.Remove(tblPic);
            DeleteIMG(vgPic.tblPicture.originalFilepath);
            db.SaveChanges();
            return View(tblPic);
        }
        public void DeleteIMG(string picture)
        {
            VanGiaPicture vgp = new VanGiaPicture();
            if (picture == null)
                return;
            var fo = picture.Substring(0,3);
            string dir = Server.MapPath("~/fileUpload/"+fo+"/"+ picture);
           
            System.IO.File.Delete(dir);
           


        }
        [HttpPost]
        public ActionResult Cancel(int id)
        {
            web_vangia_project tblproduct = db.web_vangia_project.Find(id);
            db.web_vangia_project.Remove(tblproduct);
            db.SaveChanges();
            return RedirectToAction("Index", "VanGia");



        }
        //[HttpPost]
        //public ActionResult Upload(HttpPostedFileBase file)
        //{
        //    if (file != null && file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.Combine(Server.MapPath("~/fileUpload/"), fileName);
        //        file.SaveAs(path);
        //    }

        //    return RedirectToAction("UploadDocument");
        //}
        public ActionResult IndexBuld()
        {
            return View();
        }
    }
}
