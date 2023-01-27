using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using newsSite90tv.Models.Services;

namespace newsSite90tv.Models.Repository
{
    public class sellerRepository : Iseller
    {
        private readonly IUnitOfWork _context;

        public sellerRepository(IUnitOfWork context)
        {
            _context  = context;
        }


        /*
        public async Task<SellerinfoApiObject> getsellerinfo(long sellerid)
        {
            var api = new SellerinfoApiObject();

            try
            {

                // active shopps of seller
                api.sellershops = _context.shopRepositoryUW.Get(a => a.enable && a.status == 1 && a.seller_id == sellerid,null,"Tbl_Category").Take(10).Select(a => new ShopListApiModel
                {
                    category = a.Tbl_Category.Title,
                    followcount = _context.FollowShopRepositoryUW.Get(f=>f.shop_id == a.Id).Count(),
                    id = a.Id,
                    image = a.image,
                    title = a.title,
                    viewcount = a.viewCount

                });



                api.sellerproducts = _context.ProductSellerUW.Get(a => a.seller_id == sellerid && a.Tbl_Shop.enable && a.Tbl_Shop.status == 1, null, "Tbl_Shop,Tbl_Product").Take(10).Select(a => new ProductListApiModel
                {
                    summary 
                    brand = _context.productBrandRepositoryUW.GetById(a.Tbl_Product.brand_id).name,
                    category = _context.CategoryRepositoryUW.GetById(a.Tbl_Product.cat_id).Title,
                    exist = a.isExist,
                    offpercent = a.offpercent,
                    price = a.price.RialToToman(),
                    image = a.Tbl_Product.image,
                    likecount = a.Tbl_Product.likeCount,
                    title = a.Tbl_Product.title,
                    id = a.product_id,
                    viewcount = a.Tbl_Product.viewCount,
                   
                });


                var seller = _context.salsmanRepositoryUW.GetById(sellerid);

                api.sellerinfo = new SellerinfoApiModel
                {
                    productcount = _context.ProductSellerUW.Get(a => a.isEnable && a.status == 1 && a.seller_id == sellerid).Count(), // all products
                    productactivecount = _context.ProductSellerUW.Get(a => a.isEnable && a.status == 1 && a.seller_id == sellerid).Count(), // all product can sell or active
                    salleshistory = (DateTime.Now.Date.Year - seller.dateMiladi.Year) == 0 ? 1 : (DateTime.Now.Date.Year - seller.dateMiladi.Year),
                    shopcount = _context.shopRepositoryUW.Get(a => a.seller_id == sellerid && a.enable && a.status == 1).Count(), // all seller's shop
                    shopactivecount = _context.shopRepositoryUW.Get(a => a.seller_id == sellerid && a.enable && a.status == 1).Count() //all active shops
                };



                api.otherseller = _context.salsmanRepositoryUW.Get(a => a.isEnable && a.status == 1 && a.Id != sellerid, a=>a.OrderBy(d=>d.dateMiladi), "Tbl_Userapp").Take(10).Select(a => new SellerApiListModel
                {
                    id = a.Id,
                    image = a.Tbl_Userapp.image,
                    name = a.Tbl_Userapp.firstName + " " + a.Tbl_Userapp.lastName,
                    salleshistory = (DateTime.Now.Date.Year - a.dateMiladi.Year) == 0 ? 1 : (DateTime.Now.Date.Year - a.dateMiladi.Year),
                });

                




                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception ex)
            {

                api.message = EndPointMessage.API_ERROR_MSG + ex.Message;
                api.status = EndPointMessage.API_ERROR_Std;
            }
            return api;
        }
        
        public async Task<ProductListAllApiObject> getsellerproducts(long sellerid  , int page)
        {
            var api = new ProductListAllApiObject();

            try
            {
                int paresh = (page  - 1) * 10;


                api.products = _context.ProductSellerUW.Get(a => a.seller_id == sellerid, null, "Tbl_Product").Skip(paresh).Take(10).Select(a => new ProductListApiModel
                {
                    colors = _context.ProductColorUW.Get(c => c.product_id == a.product_id, null, "Tbl_color").Select(s => s.Tbl_color.code),
                    brand = _context.productBrandRepositoryUW.GetById(a.Tbl_Product.brand_id).name,
                    category = _context.CategoryRepositoryUW.GetById(a.Tbl_Product.cat_id).Title,
                    exist = a.isExist,
                    offpercent = a.offpercent,
                    price = a.price.RialToToman(),
                    image = a.Tbl_Product.image,
                    likecount = a.Tbl_Product.likeCount,
                    title = a.Tbl_Product.title,
                    id = a.product_id,
                    viewcount = a.Tbl_Product.viewCount,

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

        public async Task<ShopListApiObject> getsellershops(long sellerid , int page)
        {
            var api = new ShopListApiObject();

            try
            {
                int paresh = (page - 1) * 10;

                api.shoplist  = _context.shopRepositoryUW.Get(a => a.enable && a.status == 1 && a.seller_id == sellerid, null, "Tbl_Category").Skip(paresh).Take(10).Select(a => new ShopListApiModel
                {
                    category = a.Tbl_Category.Title,
                    followcount = _context.FollowShopRepositoryUW.Get(f => f.shop_id == a.Id).Count(),
                    id = a.Id,
                    image = string.IsNullOrEmpty(a.image) ? "shopdefult.png" : a.image,
                    title = a.title,
                    viewcount = a.viewCount

                }).ToList();


                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;

            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }

            return api;
        }

        
        public async Task<SellerListApiObject> allseller(int page)
        {
            var api = new SellerListApiObject();

            try
            {
                int paresh = (page - 1) * 10;


                api.sellerlist = _context.salsmanRepositoryUW.Get(a => a.isEnable && a.status == 1 , a => a.OrderBy(d => d.dateMiladi), "Tbl_Userapp").Take(10).Select(a => new SellerApiListModel
                {
                    id = a.Id,
                    image = a.Tbl_Userapp.image,
                    name = a.Tbl_Userapp.firstName + " " + a.Tbl_Userapp.lastName,
                    salleshistory = (DateTime.Now.Date.Year - a.dateMiladi.Year) == 0 ? 1 : (DateTime.Now.Date.Year - a.dateMiladi.Year),
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


    */
      
    }
}
