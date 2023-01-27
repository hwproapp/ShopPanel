using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.Services;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]
    [Route("api/advertise/[action]")]
    public class advertiseController : Controller
    {

        private readonly IAdvertise _advertise;

        private readonly IAthenticate _ath;

        public advertiseController(IAdvertise advertise ,IAthenticate athenticate)
        {
            _advertise = advertise;
            _ath = athenticate;
        }

         
        //[HttpPost]
        //public async Task<AdvGetModelObject> getadvertise(int page=1)
        //{
        //    return await _advertise.getalladv(page);

        //}


        //[HttpPost]
        //public async Task<AllApi>  setadv([FromBody] AdvCreateModel model)
        //{
        //    var api = new AllApi();
        //    var token = Request.Headers["Token"];

        //    if (_ath.checkSellerToken(token) != null)
        //    {
        //        if (await _advertise.setadv(model , token))
        //        {
        //            api.message = EndPointMessage.API_ADV_ADD_MSG_SUCCESS;
        //            api.status = EndPointMessage.API_OK_Std;
        //        }
        //        else
        //        {
        //            api.message = EndPointMessage.Fail_MSG;
        //            api.status = EndPointMessage.API_Fail_Std;
        //        }
        //    }
        //    else
        //    {
        //        api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
        //        api.status = EndPointMessage.API_Token_FAIL_Std;
        //    }

        //    return api;
        //}

    }
}