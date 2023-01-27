using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class ShopListApiModel
    {

        public long id { get; set; }

        public string   title { get; set; }

        public string category { get; set; }

        public int viewcount { get; set; }

        public int  followcount { get; set; }


        public string image { get; set; }

    }
}
