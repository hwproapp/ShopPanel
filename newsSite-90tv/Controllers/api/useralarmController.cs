using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]
    [Route("api/useralarm/[action]")]
    public class useralarmController : Controller
    {

        private readonly Iuseralarm _iuseralarm;

        public useralarmController(Iuseralarm useralarm)
        {
            _iuseralarm = useralarm;
        }


       
        [HttpGet]
        public async Task<UserAlarmApiObject> GetUserAlarm(int page =1)
        {
            var token = Request.Headers["token"].ToString();
            return await _iuseralarm.Getuseralarm(token, page);
        }


        [HttpGet]
        public async Task<AllApi> SetReadUserAlarm(int id)
        {
            var token = Request.Headers["token"].ToString();
            return await _iuseralarm.SetReadUseralarm(token, id);
        }
    }
}