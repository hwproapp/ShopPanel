using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class ProductListApiModel
    {

        public long id { get; set; }

        public string title { get; set; }

        public string summary { get; set; }

        public string brand { get; set; }

        public string category { get; set; }

        public bool exist { get; set; }

        public long price { get; set; }

        public int offpercent { get; set; }

     
        public string shopname { get; set; }

        public string image { get; set; }

        public int likecount { get; set; }

        public int viewcount { get; set; }


      
    }
}
