using ApiPromotion.Interface;
using ApiPromotion.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiPromotion.Controllers
{
    public class promotionController : ApiController
    {
        MyPromotionEntities db = new MyPromotionEntities();
        
   
        private readonly IGetLogin _getLogin;
        public promotionController(IGetLogin getLogin)
        {
            _getLogin = getLogin;
        }
        public IList<clTblUser> GetLogin([FromUri]string UserName, [FromUri]string PassWord)
        {
            return _getLogin.GetLogin(UserName,PassWord).ToList();
        }
        //[HttpPost]
        //public void Register([FromUri]clTblUser tblUser)
        //{
        //    tbl_user_promotion user_promo = new tbl_user_promotion();
        //    user_promo.name_user_promotion = tblUser.name;
        //    user_promo.pass_user_promotion = tblUser.pass;
        //    db.tbl_user_promotion.Add(user_promo);
        //    db.SaveChanges();

        //}


    }
}
