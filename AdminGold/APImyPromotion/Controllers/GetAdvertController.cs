using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APImyPromotion.Models;

namespace APImyPromotion.Controllers
{
    public class GetAdvertController : ApiController
    {
        MyPromotionEntities db = new MyPromotionEntities();
        // GET: api/GetAdvert
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetAdvert/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GetAdvert
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetAdvert/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetAdvert/5
        public void Delete(int id)
        {
        }
        public IList<ListingDto> GetListing(int pageNum)
        {
            object[] para =
            {
               new SqlParameter("@PageNum",pageNum)
               
            };
            var datalogin = db.Database.SqlQuery<ListingDto>("exec  sp_GetListing @PageNum", para);
            return datalogin.ToList();
        }
        public IList<ListingDto> GetDetailListing(int idAvert)
        {
            object[] para =
            {
               new SqlParameter("@idAvert",idAvert)

            };
            var datalogin = db.Database.SqlQuery<ListingDto>("exec  sp_GetDetailListing @idAvert", para);
            return datalogin.ToList();
        }
    }
}
