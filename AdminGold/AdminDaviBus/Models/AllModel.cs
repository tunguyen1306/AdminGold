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
        public DMTRAM TblDMTRAM { get; set; }
        public List<DMTRAM> ListDMTRAM { get; set; }
        public DMTUYEN TblDMTUYEN { get; set; }
        public List<DMTUYEN> ListDMTUYEN { get; set; }

        public DMTUYENCHITIETTRAM TblDMTUYENCHITIETTRAM { get; set; }
        public List<DMTUYENCHITIETTRAM> ListDMTUYENCHITIETTRAM { get; set; }

        public LOTRINHCHOXE TblLoTrinhXe { get; set; }
        public List<LOTRINHCHOXE> ListLoTrinhXe { get; set; }

        public string Cam { get; set; }
        public string KichHoat { get; set; }
    }
   
}