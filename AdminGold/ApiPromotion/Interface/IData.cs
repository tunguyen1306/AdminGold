using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPromotion.Interface
{
   public interface IData:IDisposable
    {
        SqlConnection GetSqlconnect(string database="myprotion");
    }
}
