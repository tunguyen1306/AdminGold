using ApiPromotion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiPromotion.Controllers
{
    public class promotionController : ApiController
    {
        MyPromotionEntities db = new MyPromotionEntities();
        // GET: api/promotion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/promotion/5
        public IList<tbl_user_promotion> Get(int id)
        {
            var query = from getdata in db.tbl_user_promotion
                        where getdata.id_user_promotion == id
                        select getdata;
            return query.ToList();
        }

        // POST: api/promotion
        [HttpPost]
        public void Post(string value)
        {
            //db.tbl_user_promotion.Add(tbluser);
            //db.SaveChanges();
        }

        // PUT: api/promotion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/promotion/5
        public void Delete(int id)
        {
        }
        [HttpPost]
        public void Register([FromUri]clTblUser tblUser)
        {
            tbl_user_promotion user_promo = new tbl_user_promotion();
            user_promo.name_user_promotion = tblUser.name;
            user_promo.pass_user_promotion = tblUser.pass;
            db.tbl_user_promotion.Add(user_promo);
            db.SaveChanges();
            GetUser(user_promo.id_user_promotion, user_promo.status_user_promotion);


        }
        public IList<tbl_user_promotion> GetUser(int id,int? status)
        {
            var query = from getdata in db.tbl_user_promotion
                        where getdata.id_user_promotion == id && getdata.status_user_promotion == status
                        select getdata;
            return query.ToList();
        }


    }
}
