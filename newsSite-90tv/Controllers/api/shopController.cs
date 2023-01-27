using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.Services;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]

    [Route("api/shop/[action]")]

    public class shopController : Controller
    {
        private readonly IAthenticate _ath;

        private readonly IHostingEnvironment _hosting;

        private readonly IsaveImage _isv;
        private readonly IShop _ish;

        public shopController(IAthenticate ath, IHostingEnvironment hosting, IsaveImage isv, IShop ish)
        {
            _ath = ath;
            _hosting = hosting;
            _isv = isv;
            _ish = ish;
        }



        // get all shop

        [HttpGet]

        public async Task<ShopListApiObject> GetAllShop(int page = 1)
        {

            return await _ish.getallshop(page);
        }


        //get shop by city

        [HttpGet]

        public async Task<ShopListApiObject> GetShopByCity(int cityid, int page = 1)
        {
            return await _ish.getshopbycity(cityid, page);
        }



        // get shop products
        [HttpGet]
        public async Task<ShopProductListApiObject> GetShopProduct(long shopid, int page = 1)
        {
            return await _ish.getshopproduct(shopid, page);
        }


        // get shop detail contain lat,lot,city ,...
        [HttpGet]
        public async Task<ShopInfoApiObject> GetShopDetail(long shopid)
        {
            return await _ish.getshopdetail(shopid);
        }


        // get shop by cat

        [HttpGet]
        public async Task<ShopListApiObject> GetShopByCat(int catid, int page = 1)
        {
            return await _ish.getshopbycat(catid, page);


        }

        // for follow  and un follow shop 
        [HttpGet]
        public async Task<AllApi> followshopstate(int shopid)
        {
            var token = Request.Headers["token"];

            return await _ish.followstate(shopid, token);
        }





        // get all shop 
        [HttpPost]
        public async Task<ShopGetObject> getshops(int page = 1)
        {

            return await _ish.getshoplist(page);

        }




        // get seller's shoplist
        [HttpGet]
        public async Task<SellerShopListApiObject> Getsellershoplist(int page = 1)
        {
            var token = Request.Headers["token"];
            return await _ish.getsellershoplist(page, token);
        }




        // get shops by title => search
        [HttpPost]

        public async Task<ShopListApiObject> SearchShopByTitle([FromBody] SearchModel search)
        {

            return await _ish.searchshopbytitle(search.value, search.page);

        }





        // get seller shop's products 

        public async Task<SellerShopProductApiObject> getsellershopproducts(long id, int page = 1)
        {
            return await _ish.getsellershopproductlist(page, id);
        }









        /*

        // add new shop 
        [HttpPost]

        public async Task<AllApi> addshop([FromBody] ShopCreateModel value)
        {
            var api = new AllApi();
            var token = Request.Headers["Token"];
            if (await _ath.checkToken(token) != null)
            {
                if (await _ish.addshop(value, token))
                {
                    api.message = EndPointMessage.API_SHOP_UPDATE_MSG_SUCCESS;
                    api.status = EndPointMessage.API_OK_Std;
                }
                else
                {
                    api.message = EndPointMessage.API_SHOP_UPDATE_MSG_FAIL;
                    api.status = EndPointMessage.API_Fail_Std;
                }
            }
            else
            {
                api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                api.status = EndPointMessage.API_Token_FAIL_Std;
            }

            return api;
        }

        // update shop 

        public async Task<AllApi> editshop([FromBody] ShopUpdateModel value)
        {
            var api = new AllApi();

            if (await _ath.checkToken(Request.Headers["Token"]) != null)
            {
                if (await _ish.updateshop(value))
                {
                    api.message = EndPointMessage.API_SHOP_CREATE_MSG_SUCCESS;
                    api.status = EndPointMessage.API_OK_Std;
                }
                else
                {
                    api.message = EndPointMessage.API_SHOP_CREATE_MSG_FAIL;
                    api.status = EndPointMessage.API_Fail_Std;
                }
            }
            else
            {
                api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                api.status = EndPointMessage.API_Token_FAIL_Std;
            }

            return api;
        }

        // DELETE SHOP 
        [HttpPost]
        public async Task<AllApi> deleteshop(long id)
        {
            var api = new AllApi();

            if (await _ath.checkToken(Request.Headers["Token"]) != null)
            {
                if (await _ish.deleteshop(id))
                {
                    api.message = EndPointMessage.API_SHOP_DELETE_MSG_SUCCESS;
                    api.status = EndPointMessage.API_OK_Std;
                }
                else
                {
                    api.message = EndPointMessage.API_SHOP_DELETE_MSG_FAIL;
                    api.status = EndPointMessage.API_Fail_Std;
                }
            }
            else
            {
                api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                api.status = EndPointMessage.API_Token_FAIL_Std;
            }

            return api;
        }

        // CHANGE SHOP IMAGE 
        [HttpPost]
        public async Task<AllApi> shopimagechange([FromBody] ShopImageChangeModel val)
        {
            var api = new AllApi();

            try
            {
                if (await _ath.checkToken(Request.Headers["Token"]) != null)
                {
                    if (await _ish.changeshopimage(val))
                    {
                        api.message = EndPointMessage.API_SHOP_IMAGE_MSG_SUCCESS;
                        api.status = EndPointMessage.API_OK_Std;
                    }
                    else
                    {
                        api.message = EndPointMessage.API_SHOP_IMAGE_MSG_FAIL;
                        api.status = EndPointMessage.API_Fail_Std;
                    }
                }
                else
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }


            }
            catch (Exception ex)
            {

                api.message = ex.Message;
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }

      

        // shop detail for seller act update the shop 
        [HttpPost]
        public async Task<ShopDetailForUpdateObject> shopdetailforupdate(long id)
        {
            var api = new ShopDetailForUpdateObject();
            if (_ath.checkToken(Request.Headers["Token"]) != null)
            {
                var res = await _ish.shopdetailforupdate(id);

                if (res != null)
                {
                    api.detail = res;
                    api.message = EndPointMessage.API_OK_MSG;
                    api.status = EndPointMessage.API_OK_Std;
                }
                else
                {

                    api.message = EndPointMessage.API_Fail_MSG;
                    api.status = EndPointMessage.API_Fail_Std;
                }



            }
            else
            {
                api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                api.status = EndPointMessage.API_Token_FAIL_Std;
            }

            return api;
        }


    */



















    }
}