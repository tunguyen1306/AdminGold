using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminGold.Models;

namespace AdminGold.Controllers
{
    public class ReportController : Controller
    {
        private BusTicketEntities db = new BusTicketEntities();
        // GET: Report
        public ActionResult BaoCaoTuyen()
        {
            return View(db.DMTUYENs.ToList());
        }
        public ActionResult BaoCaoHoaDon()
        {
            return View(db.DMHOADONs.ToList());
        }
    }
}