using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class ProductOfferObject  : AllApi
    {
        public IEnumerable<ProductOfferModel> offerproducts { get; set; }

        public IEnumerable<ProductModel> newestproducts { get; set; }

        public IEnumerable<ProductModel> topviewproducts { get; set; }

        public IEnumerable<ProductModel> toplikeproducts { get; set; }


        public IEnumerable<ProductModel> topsellproducts { get; set; }
    }
}
