﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminGold.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FlotCharts()
        {
            return View("FlotCharts");
        }

        public ActionResult MorrisCharts()
        {
            return View("MorrisCharts");
        }

        public ActionResult Tables()
        {
            return View("Tables");
        }

        public ActionResult Forms()
        {
            return View("Forms");
        }

        public ActionResult Panels()
        {
            return View("Panels");
        }

        public ActionResult Buttons()
        {
            return View("Buttons");
        }

        public ActionResult Notifications()
        {
            return View("Notifications");
        }

        public ActionResult Typography()
        {
            return View("Typography");
        }

        public ActionResult Icons()
        {
            return View("Icons");
        }

        public ActionResult Grid()
        {
            return View("Grid");
        }

        public ActionResult Blank()
        {
            return View("Blank");
        }

        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email=="vangia.net@gmail.com" && password=="anhtoan77")
            {   Session["user"] = "vangia.net@gmail.com";
                return RedirectToAction("Index", "VanGia"); ;

            }
            else if (email == "anhthi@gmail.com" && password == "anhthi123")
            {
                Session["user"] = "anhthi@gmail.com";
                return RedirectToAction("Index", "Travel"); ;

            }
            else if (email == "nguyendiep@gmail.com" && password == "6593hyhh")
            {
                Session["user"] = "nguyendiep@gmail.com";
                return RedirectToAction("Index", "WebDoGo"); ;

            }
            else if (email == "coin@gmail.com" && password == "coin123")
            {
                Session["user"] = "coin@gmail.com";
                return RedirectToAction("IndexProduct", "WebCoin"); ;

            }
            return RedirectToAction("Login", "Home"); ;
        }

    }
}