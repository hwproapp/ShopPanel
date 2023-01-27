using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class SellerinfoApiObject:AllApi
    {
        public SellerinfoApiModel sellerinfo { get; set; }
        public IEnumerable<SellerApiListModel> otherseller { get; set; }
        public IEnumerable<ProductListApiModel> sellerproducts { get; set; }
        public IEnumerable<ShopListApiModel> sellershops { get; set; }
    }


    
}
