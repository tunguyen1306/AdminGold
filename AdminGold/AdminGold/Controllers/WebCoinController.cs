using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminGold.Models;
using ImageResizer;

namespace AdminGold.Controllers
{
    public class WebCoinController : Controller
    {
        private AdminGoldEntities db = new AdminGoldEntities();

        // GET: WebCoin
        public ActionResult IndexProduct()
        {
            var qrData = (from dataPro in db.tblProducts
                          join dataImg in db.tblPictures on dataPro.IdProducts equals dataImg.ProductsId
                          join dataMenu in db.tblMenus on dataPro.IdCategoryProducts equals dataMenu.IdMenu
                          where dataImg.Position == 1
                          select new AllModel { TblProduct = dataPro, TblPicture = dataImg, TblMenu = dataMenu});
            return View(qrData.ToList());
        }

        // GET: WebCoin/Details/5
        public ActionResult DetailsProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // GET: WebCoin/Create
        public ActionResult CreateProduct()
        {
            var listMenu = db.tblMenus.ToList();
            listMenu.Insert(0, new tblMenu { IdMenu = 0, NameMenu = "Chọn menu" });
            var data = new AllModel
            {
                TblMenu = new tblMenu(),
                TblProduct = new tblProduct(),
                ListMenu = listMenu
            };
            return View(data);
        }

        // POST: WebCoin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateProduct( AllModel model, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                var _tblProduct = new tblProduct();
                
                _tblProduct = model.TblProduct;
                _tblProduct.CreateDateProducts = DateTime.Now;
                db.tblProducts.Add(_tblProduct);
                db.SaveChanges();
                if (files != null && files.Length > 0)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i] != null)
                        {
                            byte[] binaryData;
                            binaryData = new Byte[files[i].InputStream.Length];
                            long bytesRead = files[i].InputStream.Read(binaryData, 0, (int)files[i].InputStream.Length);
                            files[i].InputStream.Close();
                            string base64String = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
                            SaveImg(new PictureModel { nameImg = files[i].FileName, idProducts = model.TblProduct.IdProducts, isactive = 1, index = i, cfile = base64String });
                        }
                    }
                }
                return RedirectToAction("IndexProduct");
            }

            return View(model.TblProduct);
        }
        [HttpPost]
        public void SaveImg(PictureModel newPicture)
        {
            var t = newPicture.cfile ?? "";
            var file = t.Replace("data:image/png;base64,", "");
            var photoBytes = Convert.FromBase64String(file);
            string format = "jpg";
            if (newPicture.isactive == 1)
            {
                newPicture.isactive = 1;
            }
            else
            {
                newPicture.isactive = 2;
            }
            var picture = new PictureModel
            {
                TblPicture = new tblPicture { ProductsId = newPicture.idProducts, AngleType = 0,  Converted = DateTime.Now, ToCheck = true, Type_id = 1, Title = newPicture.nameImg, Position = newPicture.isactive }
            };
            if (newPicture.idpicture == 0)
            {
                var settings = new ResizeSettings();
                settings.Scale = ScaleMode.UpscaleCanvas;
                settings.Format = format;
                settings.BackgroundColor=Color.Silver;
                //string uploadFolder = picture.DirectoryPhysical;

                string path = Server.MapPath("~/fileUpload/") + DateTime.Now.Day + DateTime.Now.Month + "/";
                // check for directory
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                // filename with placeholder for size
                if (picture.GetConvertedFileName() == null || string.IsNullOrWhiteSpace(picture.GetConvertedFileName()))
                    picture.SetFileName(DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + "_" + picture.CreateFilename() + "_{0}." + format);


                if (picture.GetFilePathPhysical(PictureModel.PictureSize.Large) != null)
                {
                    string dest = path + picture.FileName(PictureModel.PictureSize.Large);
                    settings.Width = 870;
                    settings.Height = 460;
                    if (picture.WaterMarkLarge == PictureModel.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.TblPicture.OriginalFilepath))
                        picture.TblPicture.OriginalFilepath = picture.GetFilePath(PictureModel.PictureSize.Large);
                }

                if (picture.GetFilePathPhysical(PictureModel.PictureSize.Medium) != null)
                {
                    string dest = path + picture.FileName(PictureModel.PictureSize.Medium);
                    settings.Width = 370;
                    settings.Height = 335;
                    if (picture.WaterMarkLarge == PictureModel.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.TblPicture.OriginalFilepath))
                        picture.TblPicture.OriginalFilepath = picture.GetFilePath(PictureModel.PictureSize.Medium);
                }
               

                if (picture.GetFilePathPhysical(PictureModel.PictureSize.Small) != null)
                {
                    string dest = path + picture.FileName(PictureModel.PictureSize.Small);
                
                    settings.Width = 270;
                    settings.Height = 215;
                    if (picture.WaterMarkLarge == PictureModel.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.TblPicture.OriginalFilepath))
                        picture.TblPicture.OriginalFilepath = picture.GetFilePath(PictureModel.PictureSize.Small);
                }
                if (picture.GetFilePathPhysical(PictureModel.PictureSize.Tiny) != null)
                {
                    string dest = path + picture.FileName(PictureModel.PictureSize.Tiny);
                    settings.Width = 170;
                    settings.Height = 147;
                    if (picture.WaterMarkLarge == PictureModel.WatermarkType.None)
                        ImageBuilder.Current.Build(photoBytes, dest, settings, false, false);
                    // save biggest version as original
                    if (string.IsNullOrWhiteSpace(picture.TblPicture.OriginalFilepath))
                        picture.TblPicture.OriginalFilepath = picture.GetFilePath(PictureModel.PictureSize.Tiny);
                }
                db.tblPictures.Add(picture.TblPicture);
                db.SaveChanges();
            }
            if (newPicture.idpicture > 0)
            {

                tblPicture tblpict = db.tblPictures.Find(newPicture.idpicture);
                tblpict.Title = newPicture.nameImg;
                tblpict.Position = newPicture.isactive;
                db.Entry(tblpict).State = EntityState.Modified;
                db.SaveChanges();

            }




        }
        // GET: WebCoin/Edit/5
        public ActionResult EditProduct(int? id)
        {
            var listMenu = db.tblMenus.ToList();
            listMenu.Insert(0, new tblMenu { IdMenu = 0, NameMenu = "Chọn menu" });
            var data = new AllModel
            {
                TblProduct = db.tblProducts.FirstOrDefault(x=>x.IdProducts==id),
                ListMenu = listMenu,
                ListPicture = db.tblPictures.Where(x=>x.ProductsId==id).ToList()
            };
         
            return View(data);
        }

        // POST: WebCoin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProduct(AllModel model, HttpPostedFileBase[] files, int[] imgId)
        {
            var tblProduct = db.tblProducts.Find(model.TblProduct.IdProducts);
            tblProduct.CodeProducts = model.TblProduct.CodeProducts;
            tblProduct.IdCategoryProducts = model.TblProduct.IdCategoryProducts;
            tblProduct.IdCompany = model.TblProduct.IdCompany;
            tblProduct.DescriptionProducts = model.TblProduct.DescriptionProducts;
            tblProduct.DescriptionProducts_en = model.TblProduct.DescriptionProducts_en;
            tblProduct.ShortDesProducts = model.TblProduct.ShortDesProducts;
            tblProduct.ShortDesProducts_en = model.TblProduct.ShortDesProducts_en;
            tblProduct.IdTypeProducts = model.TblProduct.IdTypeProducts;
            tblProduct.NameProducts = model.TblProduct.NameProducts;
            tblProduct.NameProducts_en = model.TblProduct.NameProducts_en;
            tblProduct.StatusProducts = model.TblProduct.StatusProducts;
            tblProduct.ModifiDateProducts = DateTime.Now;
                db.Entry(tblProduct).State = EntityState.Modified;
                db.SaveChanges();
            

            if (files != null && files.Length > 0)
            {
                if (imgId != null && imgId.Length > 0)
                {
                    var listPic = db.tblPictures.Where(T => T.ProductsId == model.TblProduct.IdProducts && !imgId.Contains(T.PictureId)).ToList();
                    foreach (var pic in listPic)
                    {
                        db.Entry(pic).State = EntityState.Deleted;
                    }
                }
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i] != null)
                    {
                        byte[] binaryData;
                        binaryData = new Byte[files[i].InputStream.Length];
                        long bytesRead = files[i].InputStream.Read(binaryData, 0, (int)files[i].InputStream.Length);
                        files[i].InputStream.Close();
                        string base64String = System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
                        SaveImg(new PictureModel { nameImg = files[i].FileName, idProducts = model.TblProduct.IdProducts, isactive = 1, index = i, cfile = base64String});
                    }
                }
            }

            db.SaveChanges();
            return RedirectToAction("IndexProduct");
            
         
        }

        // GET: WebCoin/Delete/5
        public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = db.tblProducts.Find(id);
        
            db.tblProducts.Remove(tblProduct);
            db.SaveChanges();
           
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("IndexProduct");
        }

        // POST: WebCoin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProduct tblProduct = db.tblProducts.Find(id);
            db.tblProducts.Remove(tblProduct);
            db.SaveChanges();
            return RedirectToAction("IndexProduct");
        }


        /// <summary>
        /// IndexCategory
        /// </summary>
        /// <param name="disposing"></param>


        public ActionResult IndexCategory()
        {
            return View(db.tblMenus.ToList());
        }
        public ActionResult CreateCategory()
        {
            var listMenu = db.tblMenus.ToList();
            listMenu.Insert(0, new tblMenu { IdMenu = 0, NameMenu = "Chọn menu" });
            var data = new AllModel
            {
                TblMenu = new tblMenu(),
                ListMenu = listMenu
            };
            return View(data);
        }
        [HttpPost]
        public ActionResult CreateCategory(AllModel model)
        {
            var data = new tblMenu
            {
                NameMenu = model.TblMenu.NameMenu,
                NameMenu_en = model.TblMenu.NameMenu_en,
                IdCompany = model.TblMenu.IdCompany,
                IsCategoryMenu = model.TblMenu.IsCategoryMenu,
                IsParent = model.TblMenu.IsParent,
                ShowHomeMenu = model.TblMenu.ShowHomeMenu,
                StatusMenu = model.TblMenu.StatusMenu,
                LinkMenu = model.TblMenu.LinkMenu,
                IdParentMenu = model.TblMenu.IdParentMenu,

            };
            db.tblMenus.Add(data);
            db.SaveChanges();
            return RedirectToAction("IndexCategory");
        }
        public ActionResult EditCategory(int id)
        {

            var listMenu = db.tblMenus.ToList();
            listMenu.Insert(0, new tblMenu { IdMenu = 0, NameMenu = "Chọn menu" });
            var data = new AllModel
            {
                TblMenu = db.tblMenus.FirstOrDefault(x => x.IdMenu == id),
                ListMenu = listMenu
            };
            return View(data);
        }
        [HttpPost]
        public ActionResult EditCategory(AllModel model)
        {
            var dataMenu = db.tblMenus.Find(model.TblMenu.IdMenu);
            dataMenu.NameMenu = model.TblMenu.NameMenu;
            dataMenu.NameMenu_en = model.TblMenu.NameMenu_en;
            dataMenu.IdCompany = model.TblMenu.IdCompany;
            dataMenu.IsCategoryMenu = model.TblMenu.IsCategoryMenu;
            dataMenu.IsParent = model.TblMenu.IsParent;
            dataMenu.ShowHomeMenu = model.TblMenu.ShowHomeMenu;
            dataMenu.StatusMenu = model.TblMenu.StatusMenu;
            dataMenu.LinkMenu = model.TblMenu.LinkMenu;
            dataMenu.IdParentMenu = model.TblMenu.IdParentMenu;
            db.Entry(dataMenu).State=EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexCategory");
        }
        // GET: WebCoin/Delete/5
        public ActionResult DeleteCategory(int? id)
        {
            
            tblMenu tblMenu = db.tblMenus.Find(id);
            db.tblMenus.Remove(tblMenu);
            db.SaveChanges();
            return RedirectToAction("IndexCategory");
        }




        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ApiCreateProduct(AllModel model)
        {
       
                var _tblProduct = new tblProduct();

                _tblProduct = model.TblProduct;
                _tblProduct.CreateDateProducts = DateTime.Now;
                db.tblProducts.Add(_tblProduct);
                db.SaveChanges();
            var webClient = new WebClient();
            var imageBytes = webClient.DownloadData(model.UrlImg);
            string base64String = System.Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            SaveImg(new PictureModel { nameImg = "", idProducts = model.TblProduct.IdProducts, isactive = 1, index = 1, cfile = base64String });
            return Json(model.TblProduct);
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
