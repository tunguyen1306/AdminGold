using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ApiManga.Models
{
   
    public class clsChapterDto
    {
        public string Link { get; set; }
        public int num_update { get; set; }
        public int IdAdvertManga { get; set; }
        public string NameAdvertManga { get; set; }
        public string CodeAdvertManga { get; set; }
        public string DesAdvertManga { get; set; }
        public string NameAuthorAdvertManga { get; set; }
        public int? StatusAdvertManga { get; set; }
        public int? StatusChapAdvertManga { get; set; }
        public int? CountChapAdvertManga { get; set; }
        public string TypeAdvertManga { get; set; }
        public string ImgAdvertManga { get; set; }
        public int? TypeStatusAdvertManga { get; set; }
        public string AlltypeAdvertManga { get; set; }
        public int? CountView { get; set; }
    }

}