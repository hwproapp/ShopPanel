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
    [Route("api/fav/[action]")]
    public class favController : Controller
    {
        private readonly Ifav _ifav;

        public favController(Ifav ifav)
        {
            _ifav = ifav;
        }


        [HttpGet]
        public async Task<AllApi> SetFav(long productid)
        {
            var token = Request.Headers["token"];
            return await _ifav.SetFav(productid, token);
        }


        [HttpGet]
        public async Task<AllApi> DeleteFav(int favid)
        {
            var token = Request.Headers["token"];
            return await _ifav.DelFav(favid, token);
        }



        [HttpGet]
        public async Task<FavListApiObject> GetFavList(int page =1)
        {

            var token = Request.Headers["token"];
           return await _ifav.GetFavList(page, token);
        }
    }
}