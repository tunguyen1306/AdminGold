using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebDoGo.Models;

namespace WebDoGo.Controllers
{
    public class DefaultController : Controller
    {
        private WebDoGoEntities db = new WebDoGoEntities();
        // GET: Default
        public ActionResult Index(int? page,int sort =0,string type=null,string keyword=null)
        {
            ////Sort =0 :Products New
            ////Sort =1 :Products Hot
            ////Sort =2 :Products New
            ////Sort =3 :Products New
            ViewData["page"] = sort;
            ViewData["type"] = type;
            var pagenum = page ?? 1;
            var pageSize = 8;

            Session["sort"] = sort;
            var qrData = (from dataPro in db.web_vangia_project
                          where  dataPro.vangia_status_project == 1  && dataPro.company == 4
                          select new ProductsModel { tblProject = dataPro}).ToList();
            if (type != null)
            {
                var _id = int.Parse(type.Split('-').Last());
                qrData = qrData.Where(x => x.tblProject.vangia_typeid_project == _id).ToList();
            }
            if (keyword != null)
            {
                keyword = keyword.UrlFrendly();
                qrData = qrData.Where(x => x.tblProject.vangia_name_project.UrlFrendly().Contains(keyword) || x.tblProject.vangia_content_project.UrlFrendly().Contains(keyword) || x.tblProject.vangia_tomtat_project.UrlFrendly().Contains(keyword)).ToList();
            }
            if (sort==0)
            {
                qrData = qrData.OrderByDescending(x=>x.tblProject.vangia_id_project).ToList();
            }
           else if (sort == 1)
            {
                qrData = qrData.OrderByDescending(x => x.tblProject.vangia_order_project).ToList();
            }
            else if (sort == 2)
            {
                qrData = qrData.OrderBy(x => x.tblProject.vangia_name_project).ToList();
            }
            else if (sort == 3)
            {
                qrData = qrData.OrderByDescending(x => x.tblProject.vangia_name_project).ToList();
            }
            return View(qrData.ToPagedList(pagenum, pageSize));
        }
        public ActionResult pIndex(int? page, int sort = 0, string type = null, string keyword = null)
        {
            Session["sort"]=sort;
            var pagenum = page ?? 1;
            var pageSize = 8;
            ViewData["page"] = sort;
            ViewData["type"] = type;
            ViewData["keyword"] = keyword;
            var qrData = (from dataPro in db.web_vangia_project
                          where dataPro.vangia_status_project == 1 && dataPro.company == 4
                          select new ProductsModel { tblProject = dataPro }).ToList();
            if (type != null)
            {
                var _id = int.Parse(type.Split('-').Last());
                qrData = qrData.Where(x => x.tblProject.vangia_typeid_project == _id).ToList();
            }
            if (keyword != null)
            {
                keyword = keyword.UrlFrendly();
                qrData = qrData.Where(x => x.tblProject.vangia_name_project.UrlFrendly().Contains(keyword) || x.tblProject.vangia_content_project.UrlFrendly().Contains(keyword) || x.tblProject.vangia_tomtat_project.UrlFrendly().Contains(keyword)).ToList();
            }
            if (sort == 0)
            {
                qrData = qrData.OrderByDescending(x => x.tblProject.vangia_id_project).ToList();
            }
            else if (sort == 1)
            {
                qrData = qrData.OrderByDescending(x => x.tblProject.vangia_order_project).ToList();
            }
            else if (sort == 2)
            {
                qrData = qrData.OrderBy(x => x.tblProject.vangia_name_project).ToList();
            }
            else if (sort == 3)
            {
                qrData = qrData.OrderByDescending(x => x.tblProject.vangia_name_project).ToList();
            }
            return PartialView("Index", qrData.ToPagedList(pagenum, pageSize));
        }
    
        public ActionResult Detail(string id)
        {
            var _id = int.Parse(id.Split('-').Last());
            var coiunt = 0;
            var getCount = db.web_vangia_project.FirstOrDefault(x => x.vangia_id_project == _id);
            if (getCount?.vangia_order_project != null)
            {
                coiunt = (int) getCount.vangia_order_project;
            }
            var dataprodu = db.web_vangia_project.Find(_id);
            dataprodu.vangia_order_project = coiunt + 1;
            db.Entry(dataprodu).State=EntityState.Modified;
            db.SaveChanges();
            var qrData = (from dataPro in db.web_vangia_project
                          where dataPro.vangia_status_project == 1 && dataPro.company == 4 && dataPro.vangia_id_project == _id
                          select dataPro).FirstOrDefault();

            var datareatle =
                db.web_vangia_project.Where(
                    x =>
                        x.company == 4 && x.vangia_status_project == 1 &&
                        x.vangia_typeid_project == qrData.vangia_typeid_project).ToList();
            var dataProductFeature = datareatle.OrderBy(x => Guid.NewGuid());
            var dataAll = new ProductsModel
            {
                tblProject = qrData,
                ListProject = dataProductFeature.ToList()
            };
            return View(dataAll);
        }

        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SendMail(string email)
        {
            SendEmail("donotreply@example.com", "dogonguyendiep@gmail.com", "Mail cần nhận thông tin", email);
            return RedirectToAction("Index", "Default", new { page = 1, sort = 0, type = "" });
        }
        public static bool SendEmail(string from, string to, string subject, string body)
        {
            //var emailUsername = Settings.GetSetting("EmailConfig", "Username", typeof(string));
            //var emailPassword = Settings.GetSetting("EmailConfig", "Password", typeof(string));
            try
            {
                var section = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                var message = new MailMessage("donotreply@example.com", to, subject, body) { IsBodyHtml = true };
                message.From = new MailAddress("donotreply@example.com", "", Encoding.UTF8);// Settings.GetSetting("Report", "CompanyName", typeof(string))
                message.ReplyToList.Add(from);
                var client = new SmtpClient();
                client.Port = section.Network.Port;//Settings.GetSetting("EmailConfig", "Port", typeof(int));
                client.Host = section.Network.Host;//Settings.GetSetting("EmailConfig", "Host", typeof(string));
                client.EnableSsl = section.Network.EnableSsl;//true;
                // setup up the host, increase the timeout to 60 minutes
                client.Timeout = (60 * 60 * 1000);
                client.DeliveryMethod = section.DeliveryMethod;//SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(section.Network.UserName, section.Network.Password);
                //
                client.Send(message);

            }
            catch (Exception e)
            {
                //   Tools.Logger(e.ToString(),"sendmailerr","SendMail");
                return false;
            }
            return true;
        }


    }
}