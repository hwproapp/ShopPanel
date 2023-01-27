using newsSite90tv.Controllers.api;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static newsSite90tv.Models.Repository.ProductRepository;

namespace newsSite90tv.Models.Services
{
    public interface IProduct 
    {
      
        Task<ProductDetailObject> productdetail(long id);
        Task<ProductListAutoCompleteObject> autocomplete(string data , int page);
  
      

        Task<CreateProductGetApiObject> createproductget();
        Task<AllApi> createproductpost(ProductCreateModel product, string token);


        Task<OstanApiModel> getostan();
        Task<CityApiModel> getcity(int id);
        Task<CityApiModel> getallcity(int page);
        Task<CityApiModel> getcitybyname(string title);



        Task<ProductListAllApiObject> allproduct(int page);
        Task<ProductListAllApiObject> allproductbysort(int sort, int page);
        Task<ProductListAllApiObject> getproductsbyfilter(int page  ,string title,  string brands , string price , string regions);



        Task<UpdateProductGetApiObject> updateproductget(long productId);
        Task<AllApi> updateproductpost(ProductUpdateModel model , string token); 


         Task<ProductOfferObject> homeapi();

        Task<AllApi> deleteproduct(long id , string token);


        Task<ProductListAllApiObject> getproductsbycat(int catId , int page);
        Task<ProductListAllApiObject> getproductsbytitle(string title,  int page);


        Task<SizeApiObject> getsizebycategory(int categoryid);


        Task<FactorProductApiObject> getfactorproduct(long price);


    }

   
}
