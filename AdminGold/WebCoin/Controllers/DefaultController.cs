using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebCoin.Models;

namespace WebCoin.Controllers
{
    public class DefaultController : Controller
    {
       private DataCoinEntities db = new DataCoinEntities();
        // GET: Default
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult ListNews(string id)
        {
            var _id = int.Parse(id.Split('-').Last());
            var data = db.tblMenus.FirstOrDefault(x => x.IdMenu == _id && x.IdCompany == 5);
            return View(data);
        }
        public ActionResult Detail(string id)
        {
            var _id = int.Parse(id.Split('-').Last());
            var tblProduct = db.tblProducts.FirstOrDefault(x => x.IdProducts == _id);
            return View(tblProduct);
        }
        public ActionResult GetMarketSummary(string curency)
        {
            var url = "";
            if (!string.IsNullOrEmpty(curency))
            {
                url = "https://bittrex.com/api/v1.1/public/getmarketsummary?market=" + curency;
            }
            else
            {
                url = "https://bittrex.com/api/v1.1/public/getmarketsummary";
            }
            
            var rq = new WebClient();
            String json = rq.DownloadString(url);

            return Json(new { result= json }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMarketCap()
        {
            var url = "";
            
                url = "https://api.coinmarketcap.com/v1/ticker/?limit=10";
           
            
            var rq = new WebClient();
            String json = rq.DownloadString(url);

            return Json(new { result= json }, JsonRequestBehavior.AllowGet);
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