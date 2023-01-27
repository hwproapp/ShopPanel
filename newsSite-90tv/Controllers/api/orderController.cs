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
    [Route("api/order/[action]")]
    public class orderController : Controller
    {

        private readonly Iorder iorder;

        public orderController(Iorder order)
        {
            iorder = order;
        }


        [HttpPost]
        public async  Task<AllApi> AddOrderDetail([FromBody] OrderDetailAddApiModel model)
        {
            var token = Request.Headers["token"];
            return await iorder.AddOrderDetail(model, token);
            
        }


        [HttpPost]

        public async Task<AllApi> AddOrder()
        {
            var token = Request.Headers["token"];
            return await iorder.AddOrder(token);
        }



        [HttpGet]

        public async Task<OrderApiObject> GetOrder(int idadd)
        {
            var token = Request.Headers["token"];
            return await iorder.GetOrderInfo(idadd, token);
        }


        [HttpGet]

        public async Task<OrderHistoryApiObject> GetOrderhistory()
        {
            var token = Request.Headers["token"];
            return await iorder.GetOrderHistory(token);
        }



        [HttpGet]
        public async Task<OrderDetailListApiObject> GetOrderDetail(long idorder)
        {
           
            return await iorder.GetOrderDetail(idorder);
        }


      

    }
}