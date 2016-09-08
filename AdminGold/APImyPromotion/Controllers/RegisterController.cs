using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using APImyPromotion.Models;
using ImageResizer;


namespace APImyPromotion.Controllers
{
    public class RegisterController : ApiController
    {
        MyPromotionEntities db = new MyPromotionEntities();
        // GET: api/Register
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Register/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Register
        public IList<UserDto> Post([FromBody]tbl_user_promotion user)
        {
            object[] para =
           {
               new SqlParameter("@fullName",user.full_name_user_promotion),
               new SqlParameter("@passWord",user.pass_user_promotion),
               new SqlParameter("@lastName",user.last_name_user_promotion),
               new SqlParameter("@firstName",user.first_name_user_promotion),
               new SqlParameter("@phone",user.phone_user_promotion),
               new SqlParameter("@email",user.email_user_promotion),
               
               new SqlParameter("@type_user",user.type_role_user_promotion),
               new SqlParameter("@status",user.status_user_promotion),
               new SqlParameter("@img",user.img_user_promotion)
               
            };
         var data=   db.Database.SqlQuery<UserDto>("exec  sp_register_promotion @fullName,@passWord,@lastName,@firstName,@phone,@email,@type_user,@status,@img", para);
            return data.ToList();
        }
        // PUT: api/Register/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Register/5
        public void Delete(int id)
        {
        }
        public void UploadImg(int id)
        {
        }

    }
}
