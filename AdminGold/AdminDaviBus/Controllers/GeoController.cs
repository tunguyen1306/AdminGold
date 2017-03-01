using AdminGold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminGold.Controllers
{
    public class GeoController : Controller
    {
        private BusTicketEntities db = new BusTicketEntities();

        [HttpPost]
        public IList<GeoModel> LoadCity()
        {
            var dataCity = from city in db.States
                           join cityText in db.StateTexts on city.name_id equals cityText.id
                           where cityText.language_id== "vi"
                           select new GeoModel { IdCity= city.state_id,NameCity= cityText.text };
            return dataCity.ToList();
        }

    }
}
