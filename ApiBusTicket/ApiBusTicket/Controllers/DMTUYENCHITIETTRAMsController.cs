using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiBusTicket.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiBusTicket.Controllers
{
    public class DMTUYENCHITIETTRAMsController : ApiController
    {
        private BusEntities db = new BusEntities();

        // GET: api/DMTUYENCHITIETTRAMs
        public IQueryable<DMTUYENCHITIETTRAM> GetDMTUYENCHITIETTRAMs()
        {
            return db.DMTUYENCHITIETTRAMs;
        }

        // GET: api/DMTUYENCHITIETTRAMs/5
        [ResponseType(typeof(DMTUYENCHITIETTRAM))]
        public IHttpActionResult GetDMTUYENCHITIETTRAM(int id)
        {
            DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM = db.DMTUYENCHITIETTRAMs.Find(id);
            if (dMTUYENCHITIETTRAM == null)
            {
                return NotFound();
            }

            return Ok(dMTUYENCHITIETTRAM);
        }

        // PUT: api/DMTUYENCHITIETTRAMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDMTUYENCHITIETTRAM(int id, DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dMTUYENCHITIETTRAM.ID)
            {
                return BadRequest();
            }

            db.Entry(dMTUYENCHITIETTRAM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DMTUYENCHITIETTRAMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult PostTuyenXeTram(AllModel model)
        {

            DMTUYEN account = JsonConvert.DeserializeObject<DMTUYEN>(model.StringJson);
            var CreateTuyen = new DMTUYEN();
            var idTuye_ = "";
            if (account != null)
            {
                var dataTuyen = db.DMTUYENs.Count(x => x.IDTUYEN == account.IDTUYEN);


                if (dataTuyen > 0)
                {
                    //Update
                    var UpdateTuyen = db.DMTUYENs.Find(account.IDTUYEN);
                    UpdateTuyen.CAMVE1 = account.CAMVE1;
                    UpdateTuyen.CAMVE2 = account.CAMVE2;
                    UpdateTuyen.CAMVE3 = account.CAMVE3;
                    UpdateTuyen.CAMVE4 = account.CAMVE4;
                    UpdateTuyen.CAMVE5 = account.CAMVE5;
                    UpdateTuyen.CAMVE6 = account.CAMVE6;
                    UpdateTuyen.DIENGIAIVE1 = account.DIENGIAIVE1;
                    UpdateTuyen.DIENGIAIVE2 = account.DIENGIAIVE2;
                    UpdateTuyen.DIENGIAIVE3 = account.DIENGIAIVE3;
                    UpdateTuyen.DIENGIAIVE4 = account.DIENGIAIVE4;
                    UpdateTuyen.DIENGIAIVE5 = account.DIENGIAIVE5;
                    UpdateTuyen.DIENGIAIVE6 = account.DIENGIAIVE6;
                    UpdateTuyen.GIAVE1 = account.GIAVE1;
                    UpdateTuyen.GIAVE2 = account.GIAVE2;
                    UpdateTuyen.GIAVE3 = account.GIAVE3;
                    UpdateTuyen.GIAVE4 = account.GIAVE4;
                    UpdateTuyen.GIAVE5 = account.GIAVE5;
                    UpdateTuyen.GIAVE6 = account.GIAVE6;
                    UpdateTuyen.IDVE1IDHOADON = account.IDVE1IDHOADON;
                    UpdateTuyen.IDVE2IDHOADON = account.IDVE2IDHOADON;
                    UpdateTuyen.IDVE3IDHOADON = account.IDVE3IDHOADON;
                    UpdateTuyen.IDVE4IDHOADON = account.IDVE4IDHOADON;
                    UpdateTuyen.IDVE5IDHOADON = account.IDVE5IDHOADON;
                    UpdateTuyen.IDVE6IDHOADON = account.IDVE6IDHOADON;
                    UpdateTuyen.MATRAMCUOI = account.MATRAMCUOI;
                    UpdateTuyen.MATRAMDAU = account.MATRAMDAU;
                    UpdateTuyen.MATRAMGIUA = account.MATRAMGIUA;
                    UpdateTuyen.MATUYEN = account.MATUYEN;
                    UpdateTuyen.MUCDO = account.MUCDO;
                    UpdateTuyen.TENTUYENENG = account.TENTUYENENG;
                    UpdateTuyen.TENTUYENVN = account.TENTUYENVN;
                    idTuye_ = account.IDTUYEN;

                    db.Entry(UpdateTuyen).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                  
                    var idTuyen = db.DMTUYENs.OrderByDescending(x => x.IDTUYEN).FirstOrDefault();
                    if (idTuyen!=null)
                    {
                        idTuye_ = idTuyen.IDTUYEN;
                    }
                    else
                    {
                        idTuye_ = "0";
                    }
                   
                    CreateTuyen.CAMVE1 = account.CAMVE1;
                    CreateTuyen.CAMVE2 = account.CAMVE2;
                    CreateTuyen.CAMVE3 = account.CAMVE3;
                    CreateTuyen.CAMVE4 = account.CAMVE4;
                    CreateTuyen.CAMVE5 = account.CAMVE5;
                    CreateTuyen.CAMVE6 = account.CAMVE6;
                    CreateTuyen.DIENGIAIVE1 = account.DIENGIAIVE1;
                    CreateTuyen.DIENGIAIVE2 = account.DIENGIAIVE2;
                    CreateTuyen.DIENGIAIVE3 = account.DIENGIAIVE3;
                    CreateTuyen.DIENGIAIVE4 = account.DIENGIAIVE4;
                    CreateTuyen.DIENGIAIVE5 = account.DIENGIAIVE5;
                    CreateTuyen.DIENGIAIVE6 = account.DIENGIAIVE6;
                    CreateTuyen.GIAVE1 = account.GIAVE1;
                    CreateTuyen.GIAVE2 = account.GIAVE2;
                    CreateTuyen.GIAVE3 = account.GIAVE3;
                    CreateTuyen.GIAVE4 = account.GIAVE4;
                    CreateTuyen.GIAVE5 = account.GIAVE5;
                    CreateTuyen.GIAVE6 = account.GIAVE6;
                    CreateTuyen.IDVE1IDHOADON = account.IDVE1IDHOADON;
                    CreateTuyen.IDVE2IDHOADON = account.IDVE2IDHOADON;
                    CreateTuyen.IDVE3IDHOADON = account.IDVE3IDHOADON;
                    CreateTuyen.IDVE4IDHOADON = account.IDVE4IDHOADON;
                    CreateTuyen.IDVE5IDHOADON = account.IDVE5IDHOADON;
                    CreateTuyen.IDVE6IDHOADON = account.IDVE6IDHOADON;
                    CreateTuyen.MATRAMCUOI = account.MATRAMCUOI;
                    CreateTuyen.MATRAMDAU = account.MATRAMDAU;
                    CreateTuyen.MATRAMGIUA = account.MATRAMGIUA;
                    CreateTuyen.MATUYEN = account.MATUYEN;
                    CreateTuyen.MUCDO = account.MUCDO;
                    CreateTuyen.TENTUYENENG = account.TENTUYENENG;
                    CreateTuyen.TENTUYENVN = account.TENTUYENVN;
                    CreateTuyen.THOIGIANTOANTRAM = account.THOIGIANTOANTRAM;
                    CreateTuyen.TONGTRAM = account.TONGTRAM;
                    CreateTuyen.IDTUYEN = (int.Parse(idTuye_)  + 1).ToString();
                    db.DMTUYENs.Add(CreateTuyen);
                    db.SaveChanges();
                    idTuye_ = CreateTuyen.IDTUYEN;
                    //Create
                }
                var Id = db.DMTUYENCHITIETTRAMs.Where(x => x.IDTUYEN == account.MATUYEN);
                if (Id.Any())
                {
                    foreach (var itemDetail in Id)
                    {
                        var dMTUYENCHITIETTRAM = db.DMTUYENCHITIETTRAMs.Find(itemDetail.ID);


                        db.DMTUYENCHITIETTRAMs.Remove(dMTUYENCHITIETTRAM);

                    }
                    db.SaveChanges();

                }
                var StringJson1 = model.StringJson1.Split(new string[] { "[||]" }, StringSplitOptions.None);
                foreach (var itemJS in StringJson1)
                {
                    var tram = JsonConvert.DeserializeObject<DMTRAM>(itemJS);
                    if (tram != null)
                    {
                        if (tram.ID!=0)
                        {
                            var dataTram = db.DMTRAMs.Where(x => x.MATRAM == tram.MATRAM);
                            if (dataTram.Any())
                            {
                                var UpdateTram = db.DMTRAMs.Find(dataTram.FirstOrDefault().ID);
                                UpdateTram.TENTRAM = tram.TENTRAM;
                                UpdateTram.FileTram = tram.FileTram;
                                UpdateTram.MATRAM = tram.MATRAM;
                                UpdateTram.LatLng = tram.LatLng;
                                db.Entry(UpdateTram).State = EntityState.Modified;
                            }
                            else
                            {
                                var CreateTram = new DMTRAM();
                                CreateTram.TENTRAM = tram.TENTRAM;
                                CreateTram.FileTram = tram.FileTram;
                                CreateTram.MATRAM = tram.MATRAM;
                                CreateTram.LatLng = tram.LatLng;
                                db.DMTRAMs.Add(CreateTram);


                            }
                        }
                        else
                        {
                            var CreateTram = new DMTRAM();
                            CreateTram.TENTRAM = tram.TENTRAM;
                            CreateTram.FileTram = tram.FileTram;
                            CreateTram.MATRAM = tram.MATRAM;
                            CreateTram.LatLng = tram.LatLng;
                            db.DMTRAMs.Add(CreateTram);


                        }

                        var DetailTuyenTram = new DMTUYENCHITIETTRAM();
                        DetailTuyenTram.IDTUYEN = account.MATUYEN;
                        DetailTuyenTram.MATRAM = tram.MATRAM;
                        db.DMTUYENCHITIETTRAMs.Add(DetailTuyenTram);


                    }

                }
                db.SaveChanges();

            }







            return CreatedAtRoute("DefaultApi", new { id = model.StringJson }, model);
        }
        //[HttpPost, ActionName("DMTUYENCHITIETTRAMs/PostDMTUYENCHITIETTRAM")]
        //// POST: api/DMTUYENCHITIETTRAMs
        //[ResponseType(typeof(DMTUYENCHITIETTRAM))]
        //public IHttpActionResult PostDMTUYENCHITIETTRAM(DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.DMTUYENCHITIETTRAMs.Add(dMTUYENCHITIETTRAM);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = dMTUYENCHITIETTRAM.ID }, dMTUYENCHITIETTRAM);
        //}


        // DELETE: api/DMTUYENCHITIETTRAMs/5
        [ResponseType(typeof(DMTUYENCHITIETTRAM))]
        public IHttpActionResult DeleteDMTUYENCHITIETTRAM(int id)
        {
            DMTUYENCHITIETTRAM dMTUYENCHITIETTRAM = db.DMTUYENCHITIETTRAMs.Find(id);
            if (dMTUYENCHITIETTRAM == null)
            {
                return NotFound();
            }

            db.DMTUYENCHITIETTRAMs.Remove(dMTUYENCHITIETTRAM);
            db.SaveChanges();

            return Ok(dMTUYENCHITIETTRAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DMTUYENCHITIETTRAMExists(int id)
        {
            return db.DMTUYENCHITIETTRAMs.Count(e => e.ID == id) > 0;
        }
    }

    public class TuyenTram
    {
        public string pro { get; set; }
        public string value { get; set; }
    }
}