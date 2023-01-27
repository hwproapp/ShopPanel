using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class DetailForBannerEditApiObject : AllApi
    {

        public DetailForBannerEditApiModel banneredit { get; set; }
    }

    public class DetailForBannerEditApiModel
    {
        public string title { get; set; }

        public string desc { get; set; }

        public int cat_id { get; set; }

        public int city_id { get; set; }

        public int ostan_id { get; set; }

        public IEnumerable<BannerImage> images { get; set; }
    }

    public class BannerImage
    {

        public long id { get; set; }

        public string name { get; set; }
    }
}
