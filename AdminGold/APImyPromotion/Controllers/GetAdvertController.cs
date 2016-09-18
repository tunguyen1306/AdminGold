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
        public IList<ListingDto> GetAdvertSave(int pageNum)
        {
            object[] para =
            {
               new SqlParameter("@PageNum",pageNum)

            };
            var datalogin = db.Database.SqlQuery<ListingDto>("exec  sp_GetAdvertSave @PageNum", para);
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
        public IList<ListingDto> GetAdvertRelate(int pageNum, int idCategory, int idBrand, int idAdvert)
        {
            object[] para =
            {
                new SqlParameter("@idAdvert",idAdvert),
               new SqlParameter("@idCategory",idCategory),
                new SqlParameter("@PageNum",pageNum),
               new SqlParameter("@idBrand",idBrand),

            };
            var datalogin = db.Database.SqlQuery<ListingDto>("exec  sp_GetAdvertRelate @idAdvert,@idCategory,@PageNum,@idBrand", para);
            return datalogin.ToList();
        }
    }
}
