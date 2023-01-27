using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.Services;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]
    [Route("api/useradd/[action]")]
    public class useraddController : Controller
    {
        private readonly Iuseraddress _iuseradd;

        public useraddController(Iuseraddress useradd)
        {
            _iuseradd = useradd;
        }



        [HttpPost]
        public async Task<AllApi> AddUserAddress([FromBody] AdduserAddressApiModel model)
        {
            var token = Request.Headers["token"].ToString();
            return await _iuseradd.AddAddress(model, token);
        }


        [HttpGet]
        public async Task<UserAddressApiObject> GetUserAddList()
        {
            var token = Request.Headers["token"].ToString();
            return await _iuseradd.GetUserAddressList(token);
        }


        [HttpGet]
        public async Task<AllApi> Deleteuseradd(int id)
        {
            var token = Request.Headers["token"].ToString();
            return await _iuseradd.DeleteUserAdd(id , token);
        }


    }
}