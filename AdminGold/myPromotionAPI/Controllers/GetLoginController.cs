using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using myPromotionAPI.Models;

namespace myPromotionAPI.Controllers
{
    public class GetLoginController : ApiController
    {
        MyPromotionEntities db = new MyPromotionEntities();
        // GET: api/GetLogin
        public List<tbl_user_promotion> Get()
        {
            var query = from data in db.tbl_user_promotion
                        select data;
            return query.ToList();
        }

        // GET: api/GetLogin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GetLogin
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetLogin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetLogin/5
        public void Delete(int id)
        {
        }
        public IList<UserDto> GetLogin([FromUri]string username, [FromUri]string password)
        {
            object[] para =
            {
               new SqlParameter("@userName",username),
               new SqlParameter("@passWord",password)
            };
            var datalogin = db.Database.SqlQuery<UserDto>("exec  sp_login_promotion @userName,@passWord", para);
            return datalogin.ToList();
        }
    }
}
