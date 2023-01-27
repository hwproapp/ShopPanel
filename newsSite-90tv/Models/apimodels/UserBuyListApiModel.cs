using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class UserBuyListApiModel 
    {

        public long idbuy { get; set; }
        public long idproduct { get; set; }

        public string productname { get; set; }

        public string productimage { get; set; }

        public string shopname { get; set; }

     

        public string buydate { get; set; }

        public byte  buystate { get; set; }
    }
}
