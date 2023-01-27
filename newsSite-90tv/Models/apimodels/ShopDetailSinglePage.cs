using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class ShopDetailSinglePage : AllApi
    {
        public IEnumerable<ProductListApiModel> products { get; set; }
        public IEnumerable<ProductListApiModel> offproducts { get; set; }
        public IEnumerable<ProductListApiModel> topviewproducts { get; set; }
        public IEnumerable<ProductListApiModel> likeproducts { get; set; }
        public IEnumerable<ProductListApiModel> newestproducts { get; set; }

        public ShopDetailsingleModel shopdetail { get; set; }



        public long sellerid { get; set; }
        public string sellername { get; set; }
        public string sellerimage { get; set; }

        public bool followstate { get; set; }
    }
}
