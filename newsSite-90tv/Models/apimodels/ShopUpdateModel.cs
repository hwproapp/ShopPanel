using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class ShopUpdateModel
    {
        public long shopId { get; set; }

        public string title { get; set; }

        public string summary { get; set; }

        public int cat_id { get; set; }

        //public string image { get; set; }

        public string address { get; set; }

        public int city { get; set; }

        public int ostan { get; set; }

        public byte sendtime { get; set; }

        public long sendprice { get; set; }
    }
}
