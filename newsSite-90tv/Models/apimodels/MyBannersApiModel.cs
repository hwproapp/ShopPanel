using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class MyBannersApiModel
    {
        public long idbanner { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public int viewcount { get; set; }
        public string time { get; set; }

        public int status { get; set; }
        public string image { get; set; }
    }
}
