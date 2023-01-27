using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.Services;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]
    [Route("api/properties/[action]")]
    public class propertiesController : Controller
    {

        private readonly IProperties iproperties;


        public propertiesController(IProperties properties)
        {
            iproperties = properties;
        }



        // get properties by category id
        public async Task<PropertiesApiObject> getpropertiesbycategory(int id)
        {
            return await iproperties.getpropertiesbycategory(id);
        }


        // get properties value by properties id
        public async Task<PropertiesValueApiObject> getpropertiesvaluebypropertyid(int id)
        {
            return await iproperties.getpropertyvaluebyproperty(id);
        }

    }
}