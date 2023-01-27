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
    [Route("api/appversion/[action]")]
    public class appversionController : Controller
    {
      
        private readonly IUnitOfWork _context;


        public appversionController(IUnitOfWork context)
        {
            _context = context;
        }



        public async Task<VersionApiModelObject> Checkversion(int code)
        {
            var api = new VersionApiModelObject();
            try
            {
                var version = await _context.AppversionRepositoryUW.GetLastEntityAsync(a => a.isEnable && a.status == 1);

                // no update need
                if (version.versionCode == code)
                {
                    api.message = EndPointMessage.API_OK_MSG;
                    api.status = EndPointMessage.API_OK_Std;

                    api.version = new VersionGetApiModel
                    {
                        downlink = "",
                        updatestate = false
                    };
                }
                else
                {
                    //update need

                    api.message = EndPointMessage.API_OK_MSG;
                    api.status = EndPointMessage.API_OK_Std;

                    api.version = new VersionGetApiModel
                    {
                        downlink = version.link,
                        updatestate = true
                    };
                }
            }
            catch (Exception)
            {

                api.version = null;
                api.message = EndPointMessage.API_Fail_MSG;
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }
    }
}