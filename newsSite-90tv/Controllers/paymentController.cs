using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newsSite90tv.Models;
using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using ZarinpalSandbox;

namespace newsSite90tv.Controllers
{
   
    public class paymentController : Controller
    {

        private readonly IUnitOfWork _context;


        public paymentController(IUnitOfWork context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> payzarinpal(string codeorder)
        {
           
            try
            {
              
                var order = await _context.OrderRepositoryUW.GetAsync(a => a.codeorder == codeorder && !a.isfinish, "Tbl_UserApp");

                if (order == null)
                {
                    return NotFound();
                }

                var pay = new Payment(order.sumprice);


                //// payment info
                //var chekpaymenttble =await _context.paymentRepositoryUW.GetAsync(a => a.order_id == order.Id);

                //if (chekpaymenttble  == null)
                //{
                //    payment newpament = new payment
                //    {
                //        amount = order.sumprice,
                //        appuser_id = order.appuser_id,
                //        comment = $"پرداخت فاکتور خرید محصول شماره {order.codeorder} ،پرداخت کننده:  {order.Tbl_UserApp.firstName + " " + order.Tbl_UserApp.lastName}",
                //        datemiladi = DateTime.Now,
                //        dateshamsi = DateAndTimeShamsi.DateTimeShamsi(),
                //        desbank = "پیدا نشد",
                //        sourceBank = "پیدا نشد",
                //        isenable = true,
                //        isSuccess = false,
                //        order_id = order.Id,
                //        refid = "",
                //        updatedateml = DateTime.Now,
                //        updatedatesh = DateAndTimeShamsi.DateTimeShamsi()
                //    };

                //    _context.paymentRepositoryUW.Create(newpament);
                //    await _context.saveAsync();
                //}

               

                var res =await pay.PaymentRequest($"پرداخت فاکتور شماره {order.codeorder}",
                    "http://www.qaderi002.ir/payment/payonline/" + order.Id, order.Tbl_UserApp.email, order.Tbl_UserApp.phone);

                if (res.Status == 100)
                {
                    return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Authority);
                }
                else
                {
                    return BadRequest();

                    
                }


            }
            catch (Exception)
            {

                return NotFound();
            }

           
        }


       
        [ActionName("payonline")]
        [HttpGet]
        public async Task<IActionResult> pay1234abs(long id) //order id catch
        {
            

            try
            {
                if (HttpContext.Request.Query["Status"] != "" &&
                     HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                     HttpContext.Request.Query["Authority"] != "")
                {
                    string authority = HttpContext.Request.Query["Authority"].ToString();

                    var order = await _context.OrderRepositoryUW.GetAsync(a=>a.Id== id , "Tbl_UserApp");

                    var payment = new Payment(order.sumprice);
                    
                    var res = await payment.Verification(authority);


                    // check payment status
                    if (res.Status == 100)
                    {
                        order.isfinish = true;
                        order.finishdatemiladi = DateTime.Now;
                        order.finishdateshamsi = DateAndTimeShamsi.DateTimeShamsi();

                        _context.OrderRepositoryUW.Update(order);
                        await _context.saveAsync();

                        ViewBag.message = "پرداخت موفقیت آمیز بود. کد پیگیری پرداخت شما :"+res.RefId;
                        ViewBag.type = EndPointMessage.SUCCESS_TYPE;

                        // add info to payment table 

                        var newpayment = new payment
                        {
                            isenable = true,
                            datemiladi = DateTime.Now,
                            dateshamsi = DateAndTimeShamsi.DateTimeShamsi(),
                            amount = order.sumprice,
                            appuser_id = order.appuser_id,
                            comment = $"پرداخت فاکتور خرید محصول شماره {order.codeorder} ،پرداخت کننده:  {order.Tbl_UserApp.firstName + " " + order.Tbl_UserApp.lastName}",
                            isSuccess = true,
                            refid = res.RefId.ToString(),
                            order_id = id
                        };

                        _context.paymentRepositoryUW.Create(newpayment);
                        await _context.saveAsync();



                        //end add 
                        

                        // first find details of order
                        var orderdetails = await  _context.orderdetailRepositoryUW.GetManyAsync(a => a.order_id == id);

                        foreach (var item in orderdetails)
                        {

                            //buy
                            Buy buy = new Buy
                            {
                                buyeradd_id = order.useradd_id,
                                buyer_id = order.appuser_id,
                                buystatus =  0 , // suspend
                                color_id = item.color_id,
                                createdateml = DateTime.Now,
                                createdatesh = DateAndTimeShamsi.DateTimeShamsi(),
                                isenable = true,
                                posttype = order.posttype,
                                price = item.price,
                                product_id = item.product_id,
                                qty = item.qty,
                                shop_id = item.shop_id,
                                totalprice = item.totalprice,
                               
                            };

                            _context.buyRepositoryUW.Create(buy);
                            await _context.saveAsync();


                            //sell 
                            Sell sell = new Sell
                            {

                                seller_id = _context.shopRepositoryUW.GetById(item.shop_id).seller_id,
                                totalsellprice = item.totalprice,
                                sellstatus = 0, //suspend
                                createdateml = DateTime.Now,
                                createdatesh = DateAndTimeShamsi.DateTimeShamsi(),
                                isenable = true,
                                buy_id = buy.Id,
                                price = item.price,
                                product_id = item.product_id,
                                qty = item.qty,
                                shop_id = item.shop_id,
                                totalprice = item.totalprice + 1000, // totalsell price + post price
                                removableprice = item.totalprice - 100000, // removable price - wase

                            };

                            _context.sellRepositoryUW.Create(sell);
                            await _context.saveAsync();


                        }

                    }
                    else
                    {
                        ViewBag.message = " .پرداخت با شکست مواجه شده است";
                        ViewBag.type = "info";
                    }

                }
                else
                {
                   ViewBag.message  = " .پرداخت با شکست مواجه شده است";
                   ViewBag.type  = "info";
                }
            }
            catch (Exception )
            {

                ViewBag.message = "خطایی رخ داده است. دوباره تلاش کنید";
                ViewBag.type = "danger";
            }

            return View();
        }

    }
}