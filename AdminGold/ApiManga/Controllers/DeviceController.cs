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
using ApiManga.Models;

namespace ApiManga.Controllers
{
    public class DeviceController : ApiController
    {
        private Manga1Entities db = new Manga1Entities();

        // GET: api/Device
        public List<tblDeviceManga> GetDeviceById(int id)
        {
            return db.tblDeviceMangas.ToList();
        }
        [System.Web.Http.Route("api/Device/AddDevice")]
        [System.Web.Http.HttpGet]
        public List<tblDeviceManga> AddDevice(string serial, string model, string product, string imei, string osversion, int osapiLevel, string os)
        {
            var GetSerial = db.tblDeviceMangas.Where(x => x.SerialDevice == serial).ToList();
            if (GetSerial.Count() > 0)
            {
                tblDeviceManga tblDeviceManga = db.tblDeviceMangas.Where(x => x.SerialDevice == serial).FirstOrDefault();

                db.Entry(tblDeviceManga).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                tblDeviceManga tblDeviceManga = new tblDeviceManga();
                tblDeviceManga.SerialDevice = serial;
                tblDeviceManga.ModelDevice = model;
                tblDeviceManga.ProductDevice = product;
                tblDeviceManga.ImeiDevice = imei;
                tblDeviceManga.OsVersionDevice = osversion;
                tblDeviceManga.OSApiLevelDevice = osapiLevel;
                tblDeviceManga.OsDevice = os;
                db.tblDeviceMangas.Add(tblDeviceManga);
                db.SaveChanges();
            }


            return db.tblDeviceMangas.ToList();
        }

    }
}