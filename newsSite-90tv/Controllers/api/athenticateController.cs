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
using newsSite90tv.PublicClass;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]

    [Route("api/athenticate/[action]")]
    public class athenticateController : Controller
    {
        private readonly IUnitOfWork _context;

        private readonly IAthenticate _athenticate;

        public athenticateController(IUnitOfWork context, IAthenticate athenticate)
        {
            _context = context;

            _athenticate = athenticate;
        }




        [HttpPost]
        public async Task<AllApi> register([FromBody]  RegisterApiModel model)
        {
            return await _athenticate.register(model);
        }



        [HttpGet]
        public async Task<AllApi> login(string phone)
        {
            return await _athenticate.login(phone);
        }




        [HttpGet]
        public async Task<UserAppApiObject> verifycode(string phone, string code)
        {
            return await _athenticate.verify(code, phone);
        }



        [HttpGet]
        public async Task<AllApi> preregister(string mobile)
        {
            return await _athenticate.preregister(mobile);
        }



        [HttpGet]
        public async Task<AllApi> coderesend(string mobile)
        {

            return await _athenticate.coderesend(mobile);
        }




        [HttpPost]
        public async Task<AllApi> Updateprofile([FromBody] UserAppApiModel profile)
        {


            var token = Request.Headers["token"];

            return await _athenticate.updateprofile(profile, token);
        }


    }
}