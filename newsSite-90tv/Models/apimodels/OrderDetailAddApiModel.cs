using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class OrderDetailAddApiModel
    {

        public long product_id { get; set; }
        public long shop_id { get; set; }

        public int color_id { get; set; }
        public int size_id { get; set; }
        
        public int qty { get; set; }

        public int price { get; set; }

        public int totalprice { get; set; }
    }
}
