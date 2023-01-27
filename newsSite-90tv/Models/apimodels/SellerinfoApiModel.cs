using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class SellerinfoApiModel
    {

        public int shopcount { get; set; }
        public int shopactivecount { get; set; }

        public int productcount { get; set; }
        public int productactivecount { get; set; }

        public int salleshistory { get; set; }



    }

    public class  SellerApiListModel
    {
        public long id { get; set; }
        public string image { get; set; }
        public string name { get; set; }

        public int salleshistory { get; set; }
    }
   
}
