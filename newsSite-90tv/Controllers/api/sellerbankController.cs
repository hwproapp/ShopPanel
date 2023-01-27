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
    [Route("api/sellerbank/[action]")]
    public class sellerbankController : Controller
    {
        private readonly ISellerbank _sellerbank;


        public sellerbankController(ISellerbank sellerbank)
        {
            _sellerbank = sellerbank;
        }   



        [HttpPost]
        public async Task<AllApi> AddSellerBank([FromBody] SellerBankAddApiModel model)
        {
            var token = Request.Headers["token"];
            return await _sellerbank.AddBankAccount(model, token);
        }


        [HttpPost]
        public async Task<AllApi> EditSellerBank([FromBody] SellerBankEditApiModel model)
        {
            var token = Request.Headers["token"];
            return await _sellerbank.EditSellerBank(model, token);
        }





        [HttpGet]
        public async Task<SellerBankListApiObject> GetSellerBank()
        {
            var token = Request.Headers["token"];
            return await _sellerbank.GetSellerBank(token);
        }


        [HttpGet]
        public async Task<AllApi> DeleteSellerBank(long id)
        {
            var token = Request.Headers["token"];
            return await _sellerbank.DeleteSellerBank(id , token);
        }


        [HttpGet]
        public async Task<AllApi> GetSellerBankSingle(long id)
        {
            var token = Request.Headers["token"];
            return await _sellerbank.GetSellerbanksingle(id, token);
        }




    }


}