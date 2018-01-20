using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebCoin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
         name: "detail",
         url: "bitcoin-news-trade-coin/news-trade-coin/{id}",
         defaults: new { controller = "Default", action = "Detail", id = UrlParameter.Optional }
         );
            routes.MapRoute(
         name: "list-news",
         url: "bitcoin-list-news-trade-coin/List-news-trade-coin/{id}",
         defaults: new { controller = "Default", action = "ListNews", id = UrlParameter.Optional }
         );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Home", id = UrlParameter.Optional }
            );
        }
    }
}
