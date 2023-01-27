
using Microsoft.Extensions.Primitives;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using System;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface IShop 
    {
        Task<ShopGetObject> getshoplist(int page);

        Task<ShopProductListApiObject> getshopproduct(long shopid, int page);
   
        Task<ShopInfoApiObject> getshopdetail(long shopid);
        

        
        Task<bool> addshop(ShopCreateModel shop, string token);
        Task<bool> updateshop(ShopUpdateModel shop);

        Task<bool> changeshopimage(ShopImageChangeModel value);

        Task<bool> deleteshop(long id);

        
        Task<ShopDetailForUpdateModel> shopdetailforupdate(long id);


        Task<AllApi> followstate(long id, string token);

        //.................

        Task<ShopListApiObject> getshopbycat(int id, int page);


        Task<ShopListApiObject> getallshop(int page);

      

        
        Task<ShopListApiObject> getshopbycity(int cityid, int page);
        Task<ShopListApiObject> searchshopbytitle(string serach, int page);

        Task<SellerShopListApiObject> getsellershoplist(int page , string token);


        Task<SellerShopProductApiObject> getsellershopproductlist(int page, long id);

    }
}
