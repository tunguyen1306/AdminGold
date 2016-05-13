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
                classPicture = new tblSysPicture {advert_id=int.Parse("1"),angleType=0, cms_sql_id=0,converted=DateTime.Now,convertedFilename="",convertedFilename180="",convertedFilename270="",convertedFilename90="",description="",isvalidated=true,originalFilepath="",shortdescription="",tocheck=true,type_id=1,title=productPicture.nameImg,position=1 }
            };
            var settings = new ResizeSettings();
            settings.Scale = ScaleMode.DownscaleOnly;
            settings.Format = format;
            db.tblSysPictures.Add(picture.classPicture);
            db.SaveChanges();
            return View();
        }
    }
}