using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class bannerInfoApiObject : AllApi
    {

        public bannerInfoApiModel bannerdetail { get; set; }

        public IEnumerable<string> images { get; set; }

        public IEnumerable<bannerListApiModel> samebanner { get; set; }

      

    }
}
