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
using newsSite90tv.Services;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]
    [Route("api/banner/[action]")]
    public class bannerController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly Ibanner _ibanner;
        private readonly IAthenticate _athenticate;


        public bannerController(IUnitOfWork unitOfWork, Ibanner banner, IAthenticate athenticate)
        {
            _context = unitOfWork;
            _ibanner = banner;
            _athenticate = athenticate;
        }

        [HttpGet]
        public async Task<bannerListApiObject> Getbanners(int page = 1)
        {
            return await _ibanner.Getbanners(page);
        }




        [HttpPost]
        public async Task<bannerListApiObject> Getbannersbytitle([FromBody] SearchModelBanner model)
        {
            return await _ibanner.Getbannersbytitle(model.value, model.cityid, model.catid, model.page);
        }



        [HttpGet]
        public async Task<bannerInfoApiObject> Getbannerinfo(long id)
        {
            return await _ibanner.Getbannerinfo(id);
        }






        [HttpPost]
        public async Task<AllApi> AddJobBanner([FromBody] AddJobBannerApiModel bannermodel)
        {
            var api = new AllApi();

            try
            {
                string token = Request.Headers["token"].ToString();

                var user = await _athenticate.checkToken(token);

                if (user == null)
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }
                else
                {
                    api = await _ibanner.AddJobBanner(bannermodel, user.Id);

                }

            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }




        [HttpPost]
        public async Task<AllApi> EditJobBanner([FromBody] EditBannerApiModel bannermodel)
        {

            string token = Request.Headers["token"].ToString();
            return await _ibanner.EditBanner(bannermodel, token);
        }



        [HttpGet]
        public async Task<MyBannersApiObject> GetMyBanners(int page = 1)
        {
            var token = Request.Headers["token"];
            return await _ibanner.GetMyBanners("absabs", page);
        }


        [HttpGet]
        public async Task<DetailForBannerEditApiObject> GetBannerInfoForEdit(long id)
        {
            var token = Request.Headers["token"];
            return await _ibanner.GetbannerInfoForEdit(token, id);
        }




        [HttpGet]
        public async Task<AllApi> DeleteUserBanner(long id)
        {
            var token = Request.Headers["token"];
            return await _ibanner.DeleteBanner(id, token);
        }




        /*
        [HttpGet]
        public async Task<bannerListApiObject> Getbannersbycat(int catid, int page = 1)
        {
            return await _ibanner.Getbannersbycat(catid, page);
        }

        [HttpGet]
        public async Task<bannerListApiObject> Getbannersbycity(int cityid, int page = 1)
        {
            return await _ibanner.Getbannersbycity(cityid, page);
        }


        [HttpGet]
        public async Task<bannerListApiObject> Getbannersbycityandcat(int cityid,int catid ,  int page = 1)
        {
            return await _ibanner.Getbannersbycityandcat(catid ,cityid, page);
        }
        */

    }
}