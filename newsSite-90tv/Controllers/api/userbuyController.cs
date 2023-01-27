using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.Services;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]
    [Route("api/userbuy/[action]")]
    public class userbuyController : Controller
    {
        private readonly Iuserbuy _iuserbuy;

        public userbuyController(Iuserbuy iuserbuy)
        {
            _iuserbuy = iuserbuy;
        }



        [HttpGet]
        public async Task<UserBuyListApiObject> GetUserBuyList(int state  , int page=1)
        {
            var token = Request.Headers["token"];
            return await _iuserbuy.GetUserBuylist(state, page, token);
        }


        [HttpGet]
        public async Task<UserBuyInfoApiObject> GetUserBuyInfo(long buyid)
        {
           
            return await _iuserbuy.GetUserBuyInfo(buyid);
        }


        [HttpGet]
        public async Task<AllApi> SetBuyDeliverStatus(long buyid)
        {
            var token = Request.Headers["token"];

            return await _iuserbuy.SetBuyDeliverStatus(buyid,token);
        }
    }
}