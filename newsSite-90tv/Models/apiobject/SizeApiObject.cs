using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class SizeApiObject : AllApi
    {
        public IEnumerable<Size> sizes { get; set; }


        // prevent null error
        public SizeApiObject()
        {
            sizes = new List<Size>();
        }
    }
}
