using System.IO;
using AdminGold.Models;
using ImageResizer;
using System;
using System.Web.Mvc;

namespace AdminGold.Controllers
{
    public class UploadImgController : Controller
    {
        AdminGoldEntities db = new AdminGoldEntities();
        public ActionResult Create()
        {
            return View();
        }
      
        [HttpPost]
      
        public ActionResult Create(ProductsPicture productPicture)
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
                classPicture = new tblSysPicture {advert_id=int.Parse("1"),angleType=0, cms_sql_id=0,converted=DateTime.Now,tocheck=true,type_id=1,title=productPicture.nameImg,position=1 }
            };
            var settings = new ResizeSettings();
            settings.Scale = ScaleMode.DownscaleOnly;
            settings.Format = format;

            string uploadFolder = picture.DirectoryPhysical;
          

            // check for directory
            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            // filename with placeholder for size
            if (picture.GetConvertedFileName() == null || string.IsNullOrWhiteSpace(picture.GetConvertedFileName()))
                picture.SetFileName(picture.CreateFilename() + "_{0}." + format);
           
                string dest = uploadFolder + picture.FileName(ProductsPicture.PictureSize.Large);
                settings.MaxWidth = 788;
                settings.MaxHeight = 680;
                if (picture.WaterMarkLarge == ProductsPicture.WatermarkType.None)
                    ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                // save biggest version as original
                if (string.IsNullOrWhiteSpace(picture.classPicture.originalFilepath))
                    picture.classPicture.originalFilepath = picture.GetFilePath(ProductsPicture.PictureSize.Large);

                // reset if a seekable stream. Will fail on the next resizing if not seekable
            
            db.tblSysPictures.Add(picture.classPicture);
            db.SaveChanges();
            return View();
        }
      
    }

}