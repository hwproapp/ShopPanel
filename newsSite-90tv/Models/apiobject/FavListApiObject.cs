using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class FavListApiObject: AllApi
    {

        public IEnumerable<FavListApiModel> favlist { get; set; }
    }
}
