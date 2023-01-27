using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class OrderApiModel
    {
        public long id { get; set; }

        public string codeorder { get; set; }
        public long totalprice { get; set; }
        public long sendprice { get; set; }
        public long finalprice { get; set; }



    }
}
