using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminGold.Models
{
    public class AllModel
    {
        public DMXE DmXe { get; set; } 
        public DMHOADON DmHoaDon { get; set; } 
        public List<DMHOADON> ListDmHoaDon { get; set; } 
        public List<DMXE> ListDmXe { get; set; } 
        public DMTAIXE TblDmTaiXe { get; set; } 
        public List<DMTAIXE>  ListDmTaiXe { get; set; } 
    }
   
}