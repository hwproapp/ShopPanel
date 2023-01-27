using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]
    [Route("api/appsetting/[action]")]
    public class appsettingController : Controller
    {

        private readonly IUnitOfWork _context;

        public appsettingController(IUnitOfWork context)
        {
            _context = context;
        }


       
        [HttpGet]
        public async Task<ContactGetApiObject> Getappinfo()
        {
            var api = new ContactGetApiObject();
            try
            {
                var setting = await _context.AppsettingRepositoryUW.GetSingleAsync();

                api.contactinfo = new ContactGetApiModel
                {
                    phone = setting.phone,
                    email = setting.email,
                    about = setting.about
                };


                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
                
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_Fail_MSG;
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }



    }
}