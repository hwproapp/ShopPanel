using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class ShopOtherInfoApiObject : AllApi
    {

        public List<ShopListApiModel> upfollow { get; set; }
        public List<ShopListApiModel> upview { get; set; }
    }
}
