using ApiPromotion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPromotion.Interface
{
  public  interface IGetLogin
    {
        IList<clTblUser> GetLogin(string UserName, string PassWord);
    }
}
