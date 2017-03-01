using AdminGold.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminGold.Controllers
{
    public class GeoController : Controller
    {

        private BusTicketEntities db = new BusTicketEntities();

        [HttpPost]
        public ActionResult GetCity()
        {
            var dataCity = from data in db.States
                           join datatext in db.StateTexts on data.name_id equals datatext.id
                           where datatext.language_id == "vi"
                           select new GeoModel { IdCity = data.state_id, NameCity = datatext.text,LatitudeCity= data.latitude,LongtitudeCity=data.longitude, PolygonCity=data.polygon };
            return Json(dataCity.ToList());
        }
        [HttpPost]
        public ActionResult GetDistrict(int id)
        {
            var dataDistrict = from data in db.Districts
                               join datatext in db.DistrictTexts on data.name_id equals datatext.id
                               where datatext.language_id == "vi" && data.state_id == id
                               select new GeoModel { IdDistrict = data.district_id, NameDistrict = datatext.text, LatitudeDistrict = data.latitude, LongtitudeDistrict = data.longitude };
            return Json(dataDistrict.ToList());
        }
        [HttpPost]
        public ActionResult GetWard(int id)
        {
            var dataWard = from data in db.Locations
                           join datatext in db.LocationTexts on data.name_id equals datatext.id
                           where datatext.language_id == "vi" && data.district_id == id
                           select new GeoModel { IdWard = data.location_id, NameWard = datatext.text, LatitudeWard= data.latitude, LongtitudeWard = data.longitude };
            return Json(dataWard.ToList());
        }
       [HttpPost]
        public ActionResult GetPolygon(int id)
        {
          
            var datact = db.States.Where(x=>x.state_id==id).Select(x=>x.polygon).FirstOrDefault();
            var tstateId = datact.Replace("*#", ",");
            string[] lits = tstateId.Split(',');
            var load = new List<Demo>();
            for (int i = 0; i < lits.Length; i += 2)
            {
                try
                {
                    var temp = new Demo();
                    temp.lat = float.Parse(lits[i].Replace(".", ","), CultureInfo.GetCultureInfo("vi-VN"));
                    if (i < lits.Length - 1)
                    {
                        temp.lng = float.Parse(lits[i + 1].Replace(".", ","));
                    }
                    load.Add(temp);
                }
                catch (Exception exception)
                {
                    throw;
                }

            }
          
            return Json(load);
        }
        public class Demo
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }
      

    }
}
