using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using static newsSite90tv.Models.Repository.ProductRepository;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]
    [Route("api/product/[action]")]
    public class productController : Controller
    {

        private readonly IUnitOfWork _context;


        private readonly IProduct _product;

        private readonly IAthenticate _ath;

        private readonly IHostingEnvironment _hosting;

        private readonly IsaveImage _isv;

        public productController(IProduct product, IUnitOfWork context, IAthenticate athenticate, IHostingEnvironment hosting, IsaveImage isv)
        {
            _context = context;

            _product = product;



            _ath = athenticate;

            _hosting = hosting;

            _isv = isv;
        }



        // get all city 

        [HttpGet]

        public async Task<CityApiModel> GetAllCity(int page = 1)
        {
            return await _product.getallcity(page);
        }


        // get city by name 
        [HttpPost]
        public async Task<CityApiModel> GetCityByTitle([FromBody] SearchModel model)
        {
            return await _product.getcitybyname(model.value);
        }



        // create product get 

        [HttpGet]
        public async Task<CreateProductGetApiObject> createproductget()
        {
            return await _product.createproductget();
        }



        // ADD NEW PRODUCT

        [HttpPost]
        public async Task<AllApi> createproductpost([FromBody] ProductCreateModel value)
        {

            var token = Request.Headers["token"];

            return await _product.createproductpost(value, token);
        }



        // UPDATE PRODUCT  GET

        [HttpGet]
        public async Task<UpdateProductGetApiObject> updateproductget(long id)
        {

            return await _product.updateproductget(id);
        }




        // UPDATE PRODUCT  POST
        [HttpPost]
        public async Task<AllApi> updateproductpost([FromBody] ProductUpdateModel value)
        {
            var token = Request.Headers["token"];
            return await _product.updateproductpost(value, token);
        }







        //DELETE PRODUCT 

        [HttpPost]
        public async Task<AllApi> deleteproduct(long id)
        {
            var token = Request.Headers["token"];

            return await _product.deleteproduct(id, token);
        }





        // Auto complete

        [HttpGet]
        public async Task<ProductListAutoCompleteObject> AutoComplete(string value, int page)
        {
            return await _product.autocomplete(value, page);
        }

        // All ostan 

        [HttpGet]

        public async Task<OstanApiModel> getostan()
        {
            return await _product.getostan();
        }


        [HttpGet]
        public async Task<CityApiModel> getcity(int id)
        {
            return await _product.getcity(id);
        }



        // home page  API

        [HttpGet]
        public async Task<ProductOfferObject> gethomeapi()
        {
            return await _product.homeapi();
        }



        // PRODUCT DETAILS

        [HttpGet]

        public async Task<ProductDetailObject> productdetail(long id)
        {
            return await _product.productdetail(id);
        }




        // all product 

        [HttpGet]

        public async Task<ProductListAllApiObject> Allproduct(int page = 1)
        {
            return await _product.allproduct(page);


        }

        // get product by sort
        public async Task<ProductListAllApiObject> AllProductbysort(int sort = 0, int page = 1)
        {
            return await _product.allproductbysort(sort, page);
        }


        // get products by filter
        [HttpGet]
        public async Task<ProductListAllApiObject> GetProductsByFilter(int page = 1, string title = "", string brands = "", string price = "", string region = "")
        {
            return await _product.getproductsbyfilter(page, title, brands, price, region);
        }


        // get products by title
        [HttpGet]
        public async Task<ProductListAllApiObject> GetProductsByTitle(string q, int page = 1)
        {
            return await _product.getproductsbytitle(q, page);
        }



        // get product by cat
        [HttpGet]

        public async Task<ProductListAllApiObject> GetProductsBycat(int catid, int page = 1)
        {
            return await _product.getproductsbycat(catid, page);
        }


        // get size by category selected

        [HttpGet]
        public async Task<SizeApiObject> GetSizeByCategory(int id)
        {
            return  await _product.getsizebycategory(id);
        }



        // get product factor 

        [HttpGet]

        public async Task<FactorProductApiObject> getfactorproduct(long price)
        {
            return await _product.getfactorproduct(price);
        }







    }






}