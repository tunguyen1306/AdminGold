
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AdminGold.Models;
using ImageResizer;

namespace AdminGold.Controllers
{
    public class TravelController : Controller
    {
        private AdminGoldEntities db = new AdminGoldEntities();
        // GET: Travel
        public ActionResult Index()
        {
            try
            {
                if (Session["user"].ToString() != "anhthi@gmail.com")
                {
                    return RedirectToAction("Login", "Home");
                }
                var qrData = (from dataPro in db.web_vangia_project
                              where dataPro.vangia_status_project != null && dataPro.company == 3
                              select new VanGiaPicture { tblProject = dataPro });
                return View(qrData.ToList());
            }
            catch (Exception)
            {

                return RedirectToAction("Login", "Home");
            }
            
        }
       public ActionResult IndexBlog()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session["user"].ToString() != "anhthi@gmail.com")
            {
                return RedirectToAction("Login", "Home");
            }
            var query = from data in db.tbl_blog_tra
                        where data.id_company == 3 && data.status_blog_tra == 1
                        select data;
            return View(query.ToList());
           
        }
        public ActionResult IndexSlider()
        {
            if (Session["user"] ==null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (Session["user"].ToString() != "anhthi@gmail.com")
            {
                return RedirectToAction("Login", "Home");
            }
            return View(db.web_vangia_silde.Where(x => x.company == 3).ToList());
         
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
        public ActionResult Create(web_vangia_project web_vangia_project)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                db.web_vangia_project.Add(web_vangia_project);
                db.SaveChanges();
                return RedirectToAction("Index", "Travel");
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
                return RedirectToAction("Index", "Travel");
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
            List<tblSysPicture> list = (from t in db.tblSysPictures where t.advert_id == id select t).ToList();
            foreach (tblSysPicture item in list)
            {
                db.tblSysPictures.Remove(item);
            }
            db.SaveChanges();
            db.web_vangia_project.Remove(web_vangia_project);
            db.SaveChanges();
            return RedirectToAction("Index", "Travel");
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
                RedirectToAction("Index", "Travel");
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
            return RedirectToAction("Index", "Travel");



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
            var fo = picture.Substring(0, 3);
            string dir = Server.MapPath("~/fileUpload/" + fo + "/" + picture);

            System.IO.File.Delete(dir);



        }
        [HttpPost]
        public ActionResult Cancel(int id)
        {
            web_vangia_project tblproduct = db.web_vangia_project.Find(id);
            db.web_vangia_project.Remove(tblproduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Travel");



        }
       
        public ActionResult IndexBuld()
        {
            return View();
        }




        /////////////////Slider//////////////////
         public ActionResult CreateSlider()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSlider(web_vangia_silde web_vangia_silde)
        {

            if (ModelState.IsValid)
            {
                db.web_vangia_silde.Add(web_vangia_silde);
                db.SaveChanges();
                return RedirectToAction("IndexSlider");
            }

            return View(web_vangia_silde);
        }
       
        [HttpPost]
        public ActionResult UploadImgSlider(web_vangia_silde web_vangia_silde)
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
        public ActionResult EditSlider(int? id)
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
        public ActionResult EditSlider( web_vangia_silde web_vangia_silde)
        {
            if (ModelState.IsValid)
            {
                db.Entry(web_vangia_silde).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexSlider");
            }
            return View(web_vangia_silde);
        }

        // GET: AdminSlider/Delete/5
        public ActionResult DeleteSlider(int? id)
        {
            web_vangia_silde web_vangia_silde = db.web_vangia_silde.Find(id);
            db.web_vangia_silde.Remove(web_vangia_silde);
            db.SaveChanges();
            return RedirectToAction("IndexSlider");
        }

        // POST: AdminSlider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSlider(int id)
        {
            web_vangia_silde web_vangia_silde = db.web_vangia_silde.Find(id);
            db.web_vangia_silde.Remove(web_vangia_silde);
            db.SaveChanges();
            return RedirectToAction("IndexSlider");
        }
       [HttpPost, ActionName("DeleteBlog")]
        public ActionResult DeleteBlog(int id)
        {
            web_vangia_silde web_vangia_silde = db.web_vangia_silde.Find(id);
            db.web_vangia_silde.Remove(web_vangia_silde);
            db.SaveChanges();
            return RedirectToAction("IndexBlog");
        }

        //////Blog
        public ActionResult CreateBlog()
        {
            return View();
        }

        // POST: tbl_blog_tra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateBlog(tbl_blog_tra tbl_blog_tra)
        {
            if (ModelState.IsValid)
            {
                ViewBag.des_blog_tra = tbl_blog_tra.des_blog_tra;
                tbl_blog_tra.id_company = 3;
                tbl_blog_tra.create_date_blog_tra = DateTime.Now;
                db.tbl_blog_tra.Add(tbl_blog_tra);
                db.SaveChanges();
                return RedirectToAction("IndexBlog");
            }

            return View(tbl_blog_tra);
        }

        public ActionResult EditBlog(int? id)
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
        [ValidateInput(false)]
        public ActionResult EditBlog(tbl_blog_tra tbl_blog_tra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_blog_tra).State = EntityState.Modified;
                tbl_blog_tra.id_company = 3;
                db.SaveChanges();
                return RedirectToAction("IndexBlog");
            }
            return View(tbl_blog_tra);
        }

        [HttpPost, ActionName("GetLink")]
        public JsonResult GetLink()
        {
            var path = string.Empty; var path1 = string.Empty;
            var NewPath = string.Empty;
            var fortmatName = string.Empty;
            var fileNameFull = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var file = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                if (file != null && file.ContentLength > 0)
                {

                    var fileName = Path.GetFileName(file.FileName);
                    string newFileNmae = Path.GetFileNameWithoutExtension(fileName);
                    fortmatName = Path.GetExtension(fileName);

                    NewPath = newFileNmae.Replace(newFileNmae, (DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString()).ToString());
                    fileNameFull = DateTime.Now.Day + "" + DateTime.Now.Month + "_" + NewPath + fortmatName;
                    path = Server.MapPath("~/fileUpload/") + DateTime.Now.Day + DateTime.Now.Month + "/";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    path1 = Path.Combine(path, fileNameFull);

                    file.SaveAs(path1);
                }
            }

            if (HttpContext.Request.Url != null && HttpContext.Request.Url.Host.Contains("localhost"))
            {
                path = HttpContext.Request.Url.Host + ":" + HttpContext.Request.Url.Port + "/fileUpload/" + DateTime.Now.Day + DateTime.Now.Month + "/";
            }
            else
            {
                path = ConfigurationManager.AppSettings["domain"] + DateTime.Now.Day + DateTime.Now.Month + "/";
            }
            var _fullUrl = path + fileNameFull;
            return Json(new
            {
                fullurl = _fullUrl,
                shorurl = "/fileUpload/" + DateTime.Now.Day + DateTime.Now.Month + "/" + fileNameFull,
                imgName = fileNameFull
            });
        }


    }
}