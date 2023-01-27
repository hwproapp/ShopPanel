using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.ExtraClass;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Repository
{
    public class ShopRepository : IShop
    {
        private readonly IUnitOfWork _context;
        private readonly IsaveImage _isv;
        private readonly IUserapp _iuserapp;
        private readonly IAthenticate _athenticate;




        public ShopRepository(IUnitOfWork context, IsaveImage isv, IUserapp userapp, IAthenticate athenticate)
        {
            _context = context;

            _isv = isv;

            _iuserapp = userapp;


            _athenticate = athenticate;

        }

        // get shop product
        public async Task<ShopProductListApiObject> getshopproduct(long shopid, int page)
        {
            var api = new ShopProductListApiObject();

            try
            {

                // for first load increase viewcount
                if (page == 1)
                {
                    var shop = await _context.shopRepositoryUW.GetByIdAsync(shopid);

                    shop.viewCount++;
                    _context.shopRepositoryUW.Update(shop);
                    await _context.saveAsync();

                }


                int paresh = (page - 1) * 10;

                api.productlist = _context.productRepositoryUW.Get(a => a.shop_id == shopid && a.enable && a.status == 1 , null ,  "brand,Tbl_Category").Skip(paresh).Take(10).Select(a => new ShopProductListApiModel
                {
                      id = a.Id,
                      brand = a.brand.name,
                      category = a.Tbl_Category.Title,
                      image = a.image,
                      isexist = a.isexist,
                      likecount = a.likeCount,
                      offpercent = a.offpercent,
                      price = a.price,
                      title = a.title,
                      viewcount  = a.viewCount

                });


                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }


        // follow shop
        public async Task<AllApi> followstate(long id, string token)
        {
            var api = new AllApi();
            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    var follow = await _context.FollowShopRepositoryUW.GetAsync(a => a.shop_id == id && a.userapp_id == user.Id);

                    if (follow == null)
                    {
                        FollowShop followShop = new FollowShop
                        {
                            isenable = true,
                            dateMiladi = DateTime.Now,
                            dateShamsi = DateAndTimeShamsi.DateTimeShamsi(),
                            shop_id = id,
                            time = DateAndTimeShamsi.MyTime(),
                            usertoken = token,
                            userapp_id = user.Id

                        };

                        _context.FollowShopRepositoryUW.Create(followShop);
                        await _context.saveAsync();


                        api.message = "شما این فروشگاه را دنبال می کنید";
                        api.status = EndPointMessage.API_OK_Std;
                    }
                    else
                    {
                        api.message = "شما قبلا این فروشگاه را دنبال کرده اید";
                        api.status = EndPointMessage.API_OK_Std;
                    }

                }
                else
                {
                    api.message = EndPointMessage.API_OK_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }

                //var follow = await _context.FollowShopRepositoryUW.GetAsync(a => a.shop_id == id && a.userapp_id == userId, "shop");

                //// first time

                //if (follow != null)
                //{
                //    // user want un follow
                //    if (follow.isenable)
                //    {
                //        follow.isenable = false;
                //        //follow.shop.followcount--;

                //        api.message = "شما  این فروشگاه را دنبال نمی کنید";
                //        api.state = false;

                //    }
                //    // user want follow again
                //    else
                //    {
                //        follow.isenable = true;
                //        api.state = true;
                //        // follow.shop.followcount++;
                //        api.message = "شما  این فروشگاه را دنبال می کنید";
                //    }

                //    api.status = EndPointMessage.API_OK_Std;


                //    _context.FollowShopRepositoryUW.Update(follow);
                //    await _context.saveAsync();
                //}
                //else
                //{
                //    // user doesnt follow shop => i.e for first time want follow

                //    FollowShop followShop = new FollowShop
                //    {
                //        isenable = true,
                //        dateMiladi = DateTime.Now,
                //        dateShamsi = DateAndTimeShamsi.DateTimeShamsi(),
                //        shop_id = id,
                //        time = DateAndTimeShamsi.MyTime(),
                //        usertoken = token,
                //        userapp_id = userId

                //    };




                //    // new record or new request for new foolow
                //    _context.FollowShopRepositoryUW.Create(followShop);
                //    await _context.saveAsync();

                //    api.state = true;
                //    api.message = "شما  این فروشگاه را دنبال می کنید";
                //    api.status = EndPointMessage.API_OK_Std;
                //}


            }
            catch (Exception)
            {
                api.status = EndPointMessage.API_ERROR_Std;
                api.message = EndPointMessage.API_ERROR_MSG;
            }

            return api;
        }


        // get shop by cat
        public async Task<ShopListApiObject> getshopbycat(int id, int page)
        {
            var api = new ShopListApiObject();

            try
            {
                int paresh = (page - 1) * 10;

                api.shoplist = _context.shopRepositoryUW.Get(a => a.cat_id == id && a.enable && a.status == 1, null, "Tbl_Category").Skip(paresh).Take(10).Select(a => new ShopListApiModel
                {

                    id = a.Id,
                    category = a.Tbl_Category.Title,
                    followcount = _context.FollowShopRepositoryUW.Get(s => s.shop_id == a.Id).Count(),
                    title = a.title,
                    viewcount = a.viewCount,
                    image = a.image

                }).ToList();

                api.status = EndPointMessage.API_OK_Std;
                api.message = EndPointMessage.API_OK_MSG;

            }
            catch (Exception)
            {

                api.status = EndPointMessage.API_ERROR_Std;
                api.message = EndPointMessage.API_ERROR_MSG;
            }

            return api;
        }


        // all shop
        public async Task<ShopListApiObject> getallshop(int page)
        {
            var api = new ShopListApiObject();

            try
            {
                int paresh = (page - 1) * 10;

                api.shoplist = _context.shopRepositoryUW.Get(a => a.enable && a.status == 1, null, "Tbl_Category").Skip(paresh).Take(10).Select(a => new ShopListApiModel
                {
                    id = a.Id,
                    category = a.Tbl_Category.Title,
                    followcount = _context.FollowShopRepositoryUW.Get(s => s.shop_id == a.Id).Count(),
                    title = a.title,
                    viewcount = a.viewCount,
                    image = a.image

                }).ToList();


                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }


            return api;
        }



        // get shop info contain add,city,...

        public async Task<ShopInfoApiObject> getshopdetail(long shopid)
        {
            var api = new ShopInfoApiObject();

            try
            {

                var shop = await _context.shopRepositoryUW.GetAsync(a => a.Id == shopid, "salsman");

                api.shopinfo = new ShopInfoApiModel
                {
                    address = shop.address,
                    city = _context.cityRepositoryUW.GetById(shop.city_id).title,
                    lat = shop.lat,
                    lot = shop.lot,
                    ostan = _context.ostanRepositoryUW.GetById(shop.ostan_id).title,
                    // summary = shop.summary,

                    sellerid = shop.seller_id,
                    sellername = await _iuserapp.getfullname(shop.salsman.appuser_id),
                    sellerimage = _context.userappRepositoryUW.GetById(shop.salsman.appuser_id).image,
                    sellerphone = _context.userappRepositoryUW.GetById(shop.salsman.appuser_id).phone,

                };



                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }

        public async Task<ShopListApiObject> getshopbycity(int cityid, int page)
        {
            var api = new ShopListApiObject();

            try
            {

                int paresh = (page - 1) * 10;

                api.shoplist = _context.shopRepositoryUW.Get(a => a.city_id == cityid && a.enable && a.status == 1, null, "Tbl_Category").Skip(paresh).Take(10).Select(a => new ShopListApiModel
                {
                    followcount = _context.FollowShopRepositoryUW.Get(s => s.shop_id == a.Id && s.isenable).Count(),
                    category = a.Tbl_Category.Title,
                    id = a.Id,
                    image = a.image,

                    title = a.title,
                    viewcount = a.viewCount

                }).ToList();

                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }

        public async Task<ShopListApiObject> searchshopbytitle(string serach, int page)
        {
            var api = new ShopListApiObject();

            try
            {
                int paresh = (page - 1) * 10;

                api.shoplist = _context.shopRepositoryUW.Get(a => a.title.Contains(serach) && a.enable && a.status == 1, null, "Tbl_Category").Skip(paresh).Take(10).Select(a => new ShopListApiModel
                {
                    followcount = _context.FollowShopRepositoryUW.Get(s => s.shop_id == a.Id && s.isenable).Count(),
                    category = a.Tbl_Category.Title,
                    id = a.Id,
                    image = a.image,
                    title = a.title,
                    viewcount = a.viewCount

                });


                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;

            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }



        public async Task<ShopGetObject> getshoplist(int page)
        {

            var model = new ShopGetObject();
            try
            {
                int paresh = (page - 1) * 10;

                model.shops = _context.shopRepositoryUW.Get(a => a.enable && a.status == 1, null, "Tbl_Category").Skip(paresh).Take(10).Select(a => new ShopGetModel
                {
                    id = a.Id,
                    cat_title = a.Tbl_Category.Title,
                    imagepath = a.image,
                    title = a.title

                }).ToList();



                model.message = EndPointMessage.API_OK_MSG;
                model.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception)
            {

                model.message = EndPointMessage.API_ERROR_MSG;
                model.status = EndPointMessage.API_ERROR_Std;
            }


            return model;

        }


        public async Task<commentapiobject> getshopcomments(long shopid, int page)
        {
            var api = new commentapiobject();

            try
            {
                api.comments = _context.shopCommentUW.Get(a => a.status == 1 && a.shop_id == shopid, a => a.OrderByDescending(b => b.dateMiladi), "Tbl_UserApp").Select(a => new CommentApiModel
                {
                    fullname = a.Tbl_UserApp.firstName + " " + a.Tbl_UserApp.lastName,
                    id = a.Id,
                    msg = a.body,
                    userimage = a.Tbl_UserApp.image

                }).ToList();

                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }





        public async Task<bool> addshop(ShopCreateModel shop, string token)
        {

            try
            {
                var id = _context.userappRepositoryUW.Get(a => a.token == token).FirstOrDefault().Id;

                var seller = _context.salsmanRepositoryUW.GetById(id).Id;

                var newshop = new Shop
                {
                    title = shop.title,
                    seller_id = seller,
                    address = shop.address,
                    ostan_id = shop.ostan,
                    city_id = shop.city,
                    summary = shop.summary,
                    image = await _isv.SaveShopIndexImage(Convert.FromBase64String(shop.image)),
                    cat_id = shop.cat_id,
                    enable = false,
                    status = (byte)Status.suspend,
                    //sendTime = shop.sendtime,
                    //sendprice = shop.sendprice,
                    viewCount = 0,

                };

                _context.shopRepositoryUW.Create(newshop);
                await _context.saveAsync();


                return true;


            }
            catch (Exception)
            {

                return false;
            }


        }


        public async Task<bool> updateshop(ShopUpdateModel shop)
        {
            try
            {
                var oldshop = await _context.shopRepositoryUW.GetByIdAsync(shop.shopId);

                //update start 

                oldshop.title = shop.title;
                oldshop.summary = shop.summary;
                // oldshop.sendprice = shop.sendprice;
                oldshop.ostan_id = shop.ostan;
                oldshop.city_id = shop.city;
                oldshop.address = shop.address;
                oldshop.cat_id = shop.cat_id;



                _context.shopRepositoryUW.Update(oldshop);
                await _context.saveAsync();

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }



        public async Task<bool> deleteshop(long id)
        {
            try
            {
                var shopdel = await _context.shopRepositoryUW.GetByIdAsync(id);
                shopdel.enable = false;

                _context.shopRepositoryUW.Update(shopdel);
                await _context.saveAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> changeshopimage(ShopImageChangeModel value)
        {
            try
            {
                var shop = await _context.shopRepositoryUW.GetByIdAsync(value.Id);
                var imagename = shop.image;

                await _isv.DelShopIndexImage(imagename);

                shop.image = await _isv.SaveShopIndexImage(Convert.FromBase64String(value.image));

                _context.shopRepositoryUW.Update(shop);

                await _context.saveAsync();

                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<ShopDetailForUpdateModel> shopdetailforupdate(long id)
        {

            try
            {
                var shop = await _context.shopRepositoryUW.GetByIdAsync(id);

                var model = new ShopDetailForUpdateModel();

                model.title = shop.title;
                model.shopId = shop.Id;
                model.address = shop.address;
                model.city = shop.city_id;
                model.ostan = shop.ostan_id;
                model.summary = shop.summary;
                model.cat_id = shop.cat_id;



                return model;

            }
            catch (Exception)
            {

                return null;
            }


        }


        // get shop list of shop's owner => sellers
        public async Task<SellerShopListApiObject> getsellershoplist(int page, string token)
        {
            var api = new SellerShopListApiObject();
            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    var seller = await _context.salsmanRepositoryUW.GetAsync(a => a.appuser_id == user.Id);

                    if (seller != null)
                    {
                        int paresh = (page - 1) * 10;


                        api.shoplist = _context.shopRepositoryUW.Get(a => a.seller_id == seller.Id, a => a.OrderByDescending(b => b.enable)).Skip(paresh).Take(10).Select(a => new SellerShopListApiModel
                        {
                            image = a.image,
                            title = a.title,
                            shopid = a.Id,
                            sellprice = _context.sellRepositoryUW.Get(s => s.shop_id == a.Id && s.sellstatus == 2).Sum(s => s.totalsellprice),
                            creditvalue = _context.sellRepositoryUW.Get(s => s.shop_id == a.Id && s.sellstatus == 2).Sum(s => s.totalprice),
                            status = a.status,
                            isenable = a.enable,
                            removableprice = _context.sellRepositoryUW.Get(s => s.shop_id == a.Id && s.sellstatus == 2).Sum(s => s.removableprice),
                            sellcount = _context.sellRepositoryUW.Get(s => s.shop_id == a.Id && s.sellstatus == 2).Count(),
                            payprice = _context.CheckoutRepositoryUW.Get(c => c.shop_id == a.Id).Sum(s => s.checkoutprice)

                        });


                        api.message = EndPointMessage.API_OK_MSG;
                        api.status = EndPointMessage.API_OK_Std;

                    }
                    else
                    {
                        api.message = EndPointMessage.API_SELLER_NOT_EXIST;
                        api.status = EndPointMessage.API_Fail_Std;
                    }



                }


                else
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }

            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }


            return api;

        }




        // get seller shop's product list

        public async Task<SellerShopProductApiObject> getsellershopproductlist(int page, long id)
        {
            var api = new SellerShopProductApiObject();

            try
            {

                api.products = _context.productRepositoryUW.Get(a => a.shop_id == id, a => a.OrderByDescending(b => b.enable), "brand,Tbl_Category").Select(a => new SellerShopProductApiModel
                {
                    brand = a.brand.name,
                    category = a.Tbl_Category.Title,
                    imagename = a.image,
                    likecount = a.likeCount,
                    offpercent = a.offpercent,
                    price = a.price,
                    productid = a.Id,
                    qty = a.qty,
                    title = a.title,
                    viewcount = a.viewCount,
                    isenable = a.enable,
                    status = a.status,
                    isexist = a.isexist


                });

                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;


            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }
    }
}
