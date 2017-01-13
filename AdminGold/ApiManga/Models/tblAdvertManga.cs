using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiManga.Models
{
    public class tblAdvertManga
    {
        [Key]
        public int IdAdvertManga { get; set; }
        public string NameAdvertManga { get; set; }
        public string DesAdvertManga { get; set; }
        public string NameAuthorAdvertManga { get; set; }
        public int StatusAdvertManga { get; set; }
        public int StatusChapAdvertManga { get; set; }
        public int CountChapAdvertManga { get; set; }
        public int TypeAdvertManga { get; set; }

    }
}