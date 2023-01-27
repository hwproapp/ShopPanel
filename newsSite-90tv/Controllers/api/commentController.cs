using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.ExtraClass;
using newsSite90tv.Models.Services;
using newsSite90tv.PublicClass;

namespace newsSite90tv.Controllers.api
{
    [Produces("application/json")]
    [Route("api/comment/[action]")]
    public class commentController : Controller
    {

        private readonly Icomment _comment;
      

        public commentController(Icomment icomment)
        {
            _comment = icomment;
            
        }


         // ADD COMMENT product
        [HttpPost]
        public async Task<AllApi> SetProductComment([FromBody] AddCommentModel model)
        {
            string token = Request.Headers["token"];
            return await _comment.setproductcomment(model, token);
           
        }
        

        // get product comments

        [HttpGet]

         public async Task<commentapiobject> GetProductComment(long productid , int page=1)
        {
            return await _comment.getproductcomment(productid, page);
        }


        // get shop comments 
        [HttpGet]
        public async Task<commentapiobject> GetShopComment(long shopid, int page = 1)
        {
            return await _comment.getshopcomments(shopid, page);
        }


        // ADD COMMENT  shop
        [HttpPost]
        public async Task<AllApi> SetShopComment([FromBody] AddCommentModel model)
        {
            string token = Request.Headers["token"];
            return await _comment.setshopcomment(model, token);

        }
    }
}