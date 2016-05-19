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
          
            var file = productPicture.cfile.Replace("data:image/png;base64,", "");
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
                classPicture = new tblSysPicture {advert_id= productPicture.idProducts, angleType=0, cms_sql_id=0,converted=DateTime.Now,tocheck=true,type_id=1,title=productPicture.nameImg,position=1 }
            };
            var settings = new ResizeSettings();
            settings.Scale = ScaleMode.DownscaleOnly;
            settings.Format = format;

            //string uploadFolder = picture.DirectoryPhysical;

            string path = Server.MapPath("~/fileUpload/")+DateTime.Now.Day+ DateTime.Now.Month + "/";
            // check for directory
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // filename with placeholder for size
            if (picture.GetConvertedFileName() == null || string.IsNullOrWhiteSpace(picture.GetConvertedFileName()))
                picture.SetFileName(DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString()+"_"+picture.CreateFilename() + "_{0}." + format);

            if (picture.GetFilePathPhysical(ProductsPicture.PictureSize.Large)!=null)
            {
                string dest = path + picture.FileName(ProductsPicture.PictureSize.Large);
                settings.MaxWidth = 800;
                settings.MaxHeight = 800;
                if (picture.WaterMarkLarge == ProductsPicture.WatermarkType.None)
                    ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                // save biggest version as original
                if (string.IsNullOrWhiteSpace(picture.classPicture.originalFilepath))
                    picture.classPicture.originalFilepath = picture.GetFilePath(ProductsPicture.PictureSize.Large);
            }

            if (picture.GetFilePathPhysical(ProductsPicture.PictureSize.Medium) != null)
            {
                string dest = path + picture.FileName(ProductsPicture.PictureSize.Medium);
                settings.MaxWidth = 100;
                settings.MaxHeight = 100;
                if (picture.WaterMarkLarge == ProductsPicture.WatermarkType.None)
                    ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                // save biggest version as original
                if (string.IsNullOrWhiteSpace(picture.classPicture.originalFilepath))
                    picture.classPicture.originalFilepath = picture.GetFilePath(ProductsPicture.PictureSize.Medium);
            }


            db.tblSysPictures.Add(picture.classPicture);
            db.SaveChanges();

        }
      
        [HttpPost]
        public ActionResult Create(ProductsPicture productPicture)
        {
            tbl_products_tra tblproduct = db.tbl_products_tra.Find(productPicture.idProducts);
            tblproduct.name_products_tra = productPicture.nameProduct;
            
         
                db.Entry(tblproduct).State = EntityState.Modified;
                db.SaveChanges();
            return RedirectToAction("Index", "Products");
            
          
           
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