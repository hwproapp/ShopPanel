using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class SellerShopListApiModel
    {
        public long  shopid { get; set; }

        public string image { get; set; }

        public string title { get; set; }
        
        public long sellprice { get; set; }

        public long creditvalue { get; set; }

        public long removableprice { get; set; }

        public long payprice { get; set; }

        public int sellcount { get; set; }
        
        public byte status { get; set; }

        public bool isenable { get; set; }

    }
}
