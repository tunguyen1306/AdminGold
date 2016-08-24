using APImyPromotion.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APImyPromotion.Controllers
{
    public class GetLoginController : ApiController
    {
        MyPromotionEntities db = new MyPromotionEntities();
        // GET: api/GetLogin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        public IList<UserDto>GetLogin([FromUri]string username,[FromUri]string password)
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
