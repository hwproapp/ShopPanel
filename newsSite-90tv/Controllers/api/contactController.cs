using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]
    [Route("api/contact/[action]")]
    public class contactController : Controller
    {
   
        private readonly Icontact _contact;


        public contactController( Icontact contact)
        {
           
            _contact = contact;
        }


        [HttpPost]
        public async Task<AllApi> Addcontact([FromBody] ContactApiModel model)

        {
            var token = Request.Headers["token"];

            return await _contact.addcontact(token, model);

        }


    }
}