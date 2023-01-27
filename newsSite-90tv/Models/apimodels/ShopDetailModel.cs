using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class ShopDetailModel
    {
        public long Id { get; set; }
        public string title { get; set; }

        public string summary { get; set; }

        public string seller { get; set; }

        public string cat_title { get; set; }

        public int viewCount { get; set; }

        public int follwer { get; set; }

        public string address { get; set; }

        public string ostan_title { get; set; }

        public string city_title { get; set; }

        public string image { get; set; }
    }
}
