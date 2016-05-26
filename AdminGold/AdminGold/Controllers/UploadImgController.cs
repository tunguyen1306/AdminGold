using System.IO;
using AdminGold.Models;
using ImageResizer;
using System;
using System.Web.Mvc;
using System.Data.Entity;

namespace AdminGold.Controllers
{
    public class UploadImgController : Controller
    {
        AdminGoldEntities db = new AdminGoldEntities();
     
        public ActionResult Create(tbl_products_tra tbl_product)
        {
            if (ModelState.IsValid)
            {
                db.tbl_products_tra.Add(tbl_product);
                db.SaveChanges();
             
               
            }
            return View(tbl_product);
           
        }
      
        [HttpPost]
      
        public void SaveImg(ProductsPicture productPicture)
        {
           var t =productPicture.cfile == null ? "" : productPicture.cfile;
            var file = t.Replace("data:image/png;base64,", "");
            var photoBytes = Convert.FromBase64String(file);
            string format = "jpg";
            if (productPicture.isactive == 1)
            {
                productPicture.isactive = 1;
            }
            else
            {
                productPicture.isactive = 2;
            }
            var picture = new ProductsPicture
            {
                clPicture = new tblSysPicture {advert_id= productPicture.idProducts, angleType=0, cms_sql_id=0,converted=DateTime.Now,tocheck=true,type_id=1,title=productPicture.nameImg,position= productPicture.isactive }
            };
            if (productPicture.idpicture==0)
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

                if (picture.GetFilePathPhysical(ProductsPicture.PictureSize.Large) != null)
                {
                    string dest = path + picture.FileName(ProductsPicture.PictureSize.Large);
                    settings.MaxWidth = 800;
                    settings.MaxHeight = 800;
                    if (picture.WaterMarkLarge == ProductsPicture.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.clPicture.originalFilepath))
                        picture.clPicture.originalFilepath = picture.GetFilePath(ProductsPicture.PictureSize.Large);
                }

                if (picture.GetFilePathPhysical(ProductsPicture.PictureSize.Medium) != null)
                {
                    string dest = path + picture.FileName(ProductsPicture.PictureSize.Medium);
                    settings.MaxWidth = 300;
                    settings.MaxHeight = 300;
                    if (picture.WaterMarkLarge == ProductsPicture.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.clPicture.originalFilepath))
                        picture.clPicture.originalFilepath = picture.GetFilePath(ProductsPicture.PictureSize.Medium);
                }


                db.tblSysPictures.Add(picture.clPicture);
                db.SaveChanges();
            }
            if (productPicture.idpicture>0)
            {
               
                tblSysPicture tblpict =db.tblSysPictures.Find(productPicture.idpicture);
                tblpict.title = productPicture.nameImg;
                tblpict.position = productPicture.isactive;
                db.Entry(tblpict).State = EntityState.Modified;
                db.SaveChanges();
                RedirectToAction("Index", "Products");
            }
           

        }
      
        [HttpPost]
        public ActionResult Create(ProductsPicture productPicture)
        {
            tbl_products_tra tblproduct = productPicture.tblProducts;
           
                db.Entry(tblproduct).State = EntityState.Modified;
                db.SaveChanges();
            return RedirectToAction("Index", "Products");
            
          
           
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
            tbl_products_tra tblproduct = db.tbl_products_tra.Find(id);
            db.tbl_products_tra.Remove(tblproduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");



        }
      
    }

}