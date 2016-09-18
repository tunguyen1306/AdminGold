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
    public class GetBrandController : ApiController
    {
        private MyPromotionEntities db = new MyPromotionEntities();
   
 
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
        public IList<BrandDto> GetBrandById(int idBrand)
        {
            var dataBrand = db.Database.SqlQuery<BrandDto>(@"SELECT tbl_brand_promotion.* FROM  tbl_brand_promotion
WHERE tbl_brand_promotion.status_brand_promotiom = 1
AND tbl_brand_promotion.id_brand_promotiom="+ idBrand + "ORDER BY tbl_brand_promotion.id_brand_promotiom");
            return dataBrand.ToList();
        }
        public IList<ListingDto> GetAdvertByIdBrand(int idAdvertBrand)
        {
            object[] para =
             {
               new SqlParameter("@idBrand",idAdvertBrand)

            };
            var data = db.Database.SqlQuery<ListingDto>("exec  sp_GetAdvertInBrand @idBrand", para);
            return data.ToList();
        }
        public IList<ListingDto> GetBrandByCategoryId(int idCategory)
        {
            object[] para =
             {
               new SqlParameter("@idCategory",idCategory)

            };
            var data = db.Database.SqlQuery<ListingDto>("exec  sp_GetBrandByCategoryId  @idCategory", para);
            return data.ToList();
        }
    }
}
