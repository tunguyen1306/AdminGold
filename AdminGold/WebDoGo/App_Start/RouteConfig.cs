using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDoGo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
          name: "detail",
          url: "mua-ban-do-go/chi-tiet-do-go/{id}",
          defaults: new { controller = "Default", action = "Detail", id = UrlParameter.Optional }
          );
            routes.MapRoute(
          name: "mua-ban-do-go-2",
          url: "mua-ban-do-go/do-go/{page}/{sort}",
          defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
           name: "mua-ban-do-go",
           url: "mua-ban-do-go/do-go/{page}/{sort}/{type}",
           defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
           name: "danh-sach-do-go-trang-1",
           url: "do-go/danh-sach-do-go/{page}/{sort}",
           defaults: new { controller = "Default", action = "pIndex", id = UrlParameter.Optional }
           );
            routes.MapRoute(
           name: "danh-sach-do-go-trang",
           url: "do-go/danh-sach-do-go/{page}/{sort}/{type}",
           defaults: new { controller = "Default", action = "pIndex", id = UrlParameter.Optional }
           );

            routes.MapRoute(
           name: "gioi-thieu",
           url: "do-go/gioi-thieu-do-go-nguyen-diep",
           defaults: new { controller = "Default", action = "About" }
           );
            routes.MapRoute(
         name: "lien-he",
         url: "do-go/lien-he-do-go-nguyen-diep",
         defaults: new { controller = "Default", action = "Contact" }
         );
            routes.MapRoute(
       name: "blog",
       url: "do-go/chia-se-kinh-nghiem-do-go-nguyen-diep",
       defaults: new { controller = "Default", action = "Blog" }
       );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
