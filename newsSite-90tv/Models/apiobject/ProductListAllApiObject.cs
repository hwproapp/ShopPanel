using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class ProductListAllApiObject : AllApi
    {
        public IEnumerable<ProductListApiModel> products { get; set; }


        public ProductListAllApiObject()
        {
            products = new List<ProductListApiModel>();
        }
    }
}
