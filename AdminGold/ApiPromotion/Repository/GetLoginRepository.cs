using ApiPromotion.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiPromotion.Models;
using System.Data.SqlClient;
using System.Data;

namespace ApiPromotion.Repository
{
    public class GetLoginRepository : DataRepository, IGetLogin
    {
        public GetLoginRepository(IData databaseFactory, IDbContext dbContext) : base(databaseFactory, dbContext)
        {

        }

        public IList<clTblUser> GetLogin(string UserName, string PassWord)
        {
            using (var sql = GetSqlConnect())
            {
                var data = sql.Query<clTblUser>("sp_login_promotion", new { UserName, PassWord },
                    commandType: CommandType.StoredProcedure);

                return data.ToList();


            }
        }
     
    }
}