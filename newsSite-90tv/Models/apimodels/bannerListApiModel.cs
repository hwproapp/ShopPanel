using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class bannerListApiModel
    {
        public long id { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public int viewcount { get; set; }
        public string time { get; set; }
        public string city { get; set; }
        public string desc { get; set; }
        public string image { get; set; }

    }
}
