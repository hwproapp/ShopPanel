using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]
    [Route("api/filter/[action]")]
    public class filterController : Controller
    {

        private readonly IUnitOfWork _context;

       

        public filterController(IUnitOfWork context)
        {

            _context = context;

        }



     


        // get banner filter 

        [HttpGet]
        public async Task<ProductFilterListApiObject> GetProductFilterList()
        {
            var api = new ProductFilterListApiObject();

            try
            {

                List<filter> myfilter = new List<filter>();

                //// for (int i = 0; i < 3; i++)
                // {
                //     filter filter = new filter();

                //     switch (i)
                //     {


                //         //case 0: // color 
                //         //    {
                //         //        filter.name = "رنگ محصول";
                //         //        filter.values = _context.colorRepositoryUW.Get(a => a.isenable).Select(a => new
                //         //        {
                //         //            idcolor = a.Id,
                //         //            namecolor = a.name,
                //         //            value = a.code
                //         //        });
                //         //    }
                //         //    break;

                //         case 1: // brand 
                //             {

                //             }
                //             break;

                //         //case 2: // category 
                //         //    {
                //         //        filter.name = "دسته بندی";
                //         //        filter.values = _context.CategoryRepositoryUW.Get(a => a.isenable && a.type == categoryType.product.ToByte()).Select(a => new 
                //         //        {
                //         //            idcat = a.Id,
                //         //            name = a.Title
                //         //        });
                //         //    }
                //         //    break;

                //         default:
                //             break;
                //     }


                //     myfilter.Add(filter);
                // }


                filter filter = new filter();
                filter.name = "برند";
                filter.values = _context.productBrandRepositoryUW.Get(a => a.isenable).Select(a => new
                {
                    idbrand = a.Id,
                    namebrand = a.name,
                    nameenbrand = a.nameen
                });


                myfilter.Add(filter);

                api.filters = myfilter;
                api.toprice = _context.ProductSellerUW.GetMax(a => a.price);

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