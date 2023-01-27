using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class ShopProductListApiModel
    {
        public long id { get; set; }

        public string title { get; set; }
        
        public long price { get; set; }

        public int offpercent { get; set; }


        public bool isexist { get; set; }

        public string category { get; set; }

        public string brand { get; set; }


        public int viewcount { get; set; }


        public int likecount { get; set; }


        public string image { get; set; }


    }
}
