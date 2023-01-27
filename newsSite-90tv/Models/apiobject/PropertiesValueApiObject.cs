using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class PropertiesValueApiObject : AllApi
    {
        public IEnumerable<PropertiesValue> propertiesValues { get; set; }
    }
}
