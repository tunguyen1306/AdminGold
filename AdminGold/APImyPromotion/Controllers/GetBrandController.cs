using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APImyPromotion.Models;

namespace APImyPromotion.Controllers
{
    public class GetBrandController : ApiController
    {
        private MyPromotionEntities db = new MyPromotionEntities();
        // GET: api/GetBrand
       
        // GET: api/GetBrand/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GetBrand
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetBrand/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetBrand/5
        public void Delete(int id)
        {
        }
        public IList<BrandDto> GetBrand()
        {
            var dataBrand = db.Database.SqlQuery<BrandDto>(@"SELECT        tbl_brand_promotion.*
FROM            tbl_brand_promotion
WHERE tbl_brand_promotion.status_brand_promotiom = 1
ORDER BY tbl_brand_promotion.id_brand_promotiom");
            return dataBrand.ToList();
        }
    }
}
