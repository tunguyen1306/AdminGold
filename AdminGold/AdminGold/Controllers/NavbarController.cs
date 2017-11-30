using AdminGold.Domain;
using AdminGold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminGold.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Navbar
        public ActionResult Index()
        {
            var data = new Data();
            var listId = new List<int>();
            listId = Session["user"].ToString() == "anhthi@gmail.com" ? new List<int> { 9,10,11,13 } : new List<int> {2,4,6,7,8 };
            return PartialView("_Navbar", data.navbarItems().ToList().Where(x => listId.Contains(x.Id)));

        }
    }
}