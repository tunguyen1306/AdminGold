using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APImyPromotion.Models
{
    public class ListingDto
    {
        public int AdvertId { get; set; }
        public string AdvertName { get; set; }
        public string AdvertDescription { get; set; }
        public DateTime AdvertCreatedDate { get; set; }
        public DateTime AdvertExpiresDate { get; set; }
        public DateTime AdvertModifiDate { get; set; }
        public DateTime AdvertPostedDate { get; set; }
        public string AdvertStreet { get; set; }
        public string AdvertCity { get; set; }
        public string AdvertDistrict { get; set; }
        public string AdvertWard { get; set; }
        public string CategoryName { get; set; }
        public string AdvertImg { get; set; }

    }
}