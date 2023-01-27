using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class ProductOfferModel
    {
        public long Id { get; set; }

        public string title { get; set; }


        public string summary { get; set; }


        public long shopid { get; set; }

        public string shopname { get; set; }

        public string image { get; set; }

        public long price { get; set; }

        public int offpercent { get; set; }

     

    }
}
