using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class OrderDetailListApiObject : AllApi
    {

        public IEnumerable<OrderDetailListApiModel> orderdetails { get; set; }
    }
}
