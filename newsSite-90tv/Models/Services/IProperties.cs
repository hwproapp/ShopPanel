using newsSite90tv.Models.apiobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface IProperties
    {
        Task<PropertiesApiObject> getpropertiesbycategory(int categoryid);
        Task<PropertiesValueApiObject> getpropertyvaluebyproperty(int propertyid);
    }
}
