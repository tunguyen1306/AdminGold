using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiManga.Models
{
    public class clsAllAdvert
    {
        public int row_num { get; set; }
        public int num_update { get; set; }
        public List<tblAdvertManga> ListAdvertManga { get; set; }
        public List<tblChapterManga> ListChapterManga { get; set; }
        public List<tblImgManga> ListImgManga { get; set; }

        public tblAdvertManga tblAdvertManga { get; set; }
        public tblChapterManga tblChapterManga { get; set; }
        public tblImgManga tblImgManga { get; set; }
    }
}