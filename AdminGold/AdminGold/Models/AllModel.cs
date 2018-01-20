using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminGold.Models
{
    public class AllModel
    {
        public tblMenu TblMenu { get; set; }
        public string NameMenuParent { get; set; }
        public string UrlImg { get; set; }
        public List<tblMenu> ListMenu { get; set; }
        public tblProduct TblProduct { get; set; }
        public List<tblProduct> ListProduct { get; set; }

        public tblPicture TblPicture { get; set; }
        public List<tblPicture> ListPicture { get; set; }


    }
   
}