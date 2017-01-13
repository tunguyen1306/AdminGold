using ApiManga.Contex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ApiManga.Controllers
{
    public class AdvertController : ApiController
    {
        ConnectContext db = new ConnectContext();

        public string GetAdvert()
        {
            var dataAdvert = from dataAd in db.tblAdvertManga
                             select dataAd;
            return dataAdvert.FirstOrDefault().ToString();
        }

    }
}
