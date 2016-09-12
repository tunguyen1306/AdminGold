using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APImyPromotion.Models;

namespace APImyPromotion.Controllers
{
    public class SlideController : ApiController
    {
        private MyPromotionEntities db = new MyPromotionEntities();
    

        // GET: api/Slide/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Slide
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Slide/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Slide/5
        public void Delete(int id)
        {
        }
        public IList<SlideDto> GetSlide()
        {
            var datalogin = db.Database.SqlQuery<SlideDto>("select * from tbl_slide_promotion");
            return datalogin.ToList();
        }
    }
}
