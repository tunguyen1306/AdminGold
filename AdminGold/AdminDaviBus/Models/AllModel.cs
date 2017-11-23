using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminGold.Models
{
    public class AllModel
    {
        public DMXE DmXe { get; set; } 
        public DMTAIXE TblDmTaiXe { get; set; } 
        public List<DMTAIXE>  ListDmTaiXe { get; set; } 
    }
    public class DmTaiXeModel
    {
      public string MaTaiXe { get; set; }
      public string TenTaiXe { get; set; }
    }
}