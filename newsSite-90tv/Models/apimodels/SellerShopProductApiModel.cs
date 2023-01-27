using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class SellerShopProductApiModel
    {
        public long productid { get; set; }

        public string title { get; set; }


        public string category { get; set; }

        public string brand { get; set; }


        public long price { get; set; }

        public int offpercent { get; set; }


        public int qty { get; set; }


        public string imagename { get; set; }

        public int likecount { get; set; }

        public int viewcount { get; set; }


        public int status { get; set; }

        public bool isenable { get; set; }

        public bool isexist { get; set; }
    }
}
