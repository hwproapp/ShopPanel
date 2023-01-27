using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class FavListApiModel
    {
        public int idfav { get; set; }
        public long idproduct { get; set; }
        public string productname { get; set; }
        public string productimage { get; set; }
    }
}
