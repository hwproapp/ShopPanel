using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Repository
{
    public class OrderRepository : Iorder
    {
        private readonly IUnitOfWork _context;
        private readonly IAthenticate _athenticate;

        public OrderRepository(IUnitOfWork context , IAthenticate athenticate)
        {
            _context = context;
            _athenticate = athenticate;
        }

       

        public async Task<AllApi> AddOrder(string token)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    // new order 
                    Order neworder = new Order
                    {

                        appuser_id = user.Id,
                        isEnable = true,
                        datemiladi = DateTime.Now,
                        dateshamsi = DateAndTimeShamsi.DateTimeShamsi(),
                        codeorder = Guid.NewGuid().ToString().Replace("-", ""),
                        finishdatemiladi = DateTime.Now,
                        finishdateshamsi = "",
                        isfinish = false,
                        sumprice = 0,
                        postprice = 0,
                        posttype = 0,
                        useradd_id = -1
                        
                    };

                    _context.OrderRepositoryUW.Create(neworder);
                    await _context.saveAsync();


                    api.message = EndPointMessage.API_OK_MSG;
                    api.status = EndPointMessage.API_OK_Std;
                }
                else
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }
            }
            catch (Exception)
            {

                api.message = "خطا در ثبت سفارش خطا در سرور";
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }

        public async Task<AllApi> AddOrderDetail(OrderDetailAddApiModel model, string token)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    // get last order create 
                    var order = await GetLastOrder(user.Id);

                    if (order != null)
                    {
                        var sumprice = order.sumprice; // 2000
                        var sendprice = order.postprice; // 1000

                        //sumprice += model.totalprice; // 3000
                       // sendprice += _context.shopRepositoryUW.GetById(model.shop_id).sendprice; //2000

                        orderDetail orderdetail = new orderDetail
                        {
                            color_id = model.color_id,
                            qty = model.qty,
                            size_id = model.size_id,
                            isenable = true,
                            order_id = order.Id,
                            price = model.price,
                            totalprice = model.totalprice,
                            product_id = model.product_id,
                            shop_id = model.shop_id,
                            
                        };


                        _context.orderdetailRepositoryUW.Create(orderdetail);
                        await _context.saveAsync();


                        order.sumprice = sumprice + sendprice;
                        order.postprice = sendprice;

                        _context.OrderRepositoryUW.Update(order);
                        await _context.saveAsync();

                        api.message = EndPointMessage.API_OK_MSG;
                        api.status = EndPointMessage.API_OK_Std;


                    }
                    else
                    {
                        api.message = "خطا در ثبت سفارش خطا در سرور";
                        api.status = EndPointMessage.API_Fail_Std;
                    }
                }
                else
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }



              

            }
            catch (Exception ex)
            {

                api.message = "خطا در ثبت سفارش" +ex.ToString();
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }

        public async Task<OrderApiObject> GetOrderInfo(int idaddress, string token)
        {
            var api = new OrderApiObject();
            try
            {
                var user = await _athenticate.checkToken(token);

                if (user == null)
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }
                else
                {
                    var order = await GetLastOrder(user.Id);


                    // update order user address
                    if (order != null)
                    {
                        order.useradd_id = idaddress;

                        _context.OrderRepositoryUW.Update(order);
                        await _context.saveAsync();



                        api.order = new OrderApiModel
                        {
                            id = order.Id,
                            codeorder = order.codeorder,
                           // finalprice = order.sumprice.RialToToman(),
                           // sendprice = order.postprice.RialToToman(),
                           // totalprice  = (order.sumprice - order.postprice).RialToToman()
                        };

                        api.message = EndPointMessage.API_OK_MSG;
                        api.status = EndPointMessage.API_OK_Std;
                    }
                    else
                    {

                        // order not exist which never happen this level
                        api.message = EndPointMessage.API_ERROR_MSG;
                        api.status = EndPointMessage.API_ERROR_Std;
                    }
                

                }
            }
            catch (Exception ex)
            {
                api.message = EndPointMessage.API_ERROR_MSG + ex.ToString();
                api.status = EndPointMessage.API_ERROR_Std;

            }

            return api;
        }

        public async Task<Order> GetLastOrder(long appuserid)
        {
            return _context.OrderRepositoryUW.Get(a => !a.isfinish && a.isEnable && a.appuser_id == appuserid, a => a.OrderByDescending(b => b.Id)).FirstOrDefault();
        }



        public async Task<OrderHistoryApiObject> GetOrderHistory(string token)
        {
            var api = new OrderHistoryApiObject();
            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    api.orderhistory = _context.OrderRepositoryUW.Get(a => a.isEnable && a.appuser_id == user.Id ,a=>a.OrderByDescending(b=>b.datemiladi)).Select(a=>new OrderHistoryApiModel
                    {
                        codeorder = a.codeorder,
                        idorder = a.Id,
                        isfinish = a.isfinish,
                        totalprice = a.sumprice,
                        createdate = a.dateshamsi + " " + DateAndTimeShamsi.MyTime(a.datemiladi),
                        paydate = a.finishdateshamsi + " " +DateAndTimeShamsi.MyTime(a.finishdatemiladi)

                    });

                    api.message = EndPointMessage.API_OK_MSG;
                    api.status = EndPointMessage.API_OK_Std;
                }
                else
                {
                    api.message = EndPointMessage.API_ERROR_MSG;
                    api.status = EndPointMessage.API_ERROR_Std;
                }
                
               
            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }



        public async Task<OrderDetailListApiObject> GetOrderDetail(long idorder)
        {
            var api = new OrderDetailListApiObject();

            try
            {
                api.orderdetails = _context.orderdetailRepositoryUW.Get(a => a.isenable && a.order_id == idorder, null).Select(a => new OrderDetailListApiModel
                {
                    color = _context.colorRepositoryUW.GetById(a.color_id)!=null ? _context.colorRepositoryUW.GetById(a.color_id).code : "",
                    count = a.qty,
                    finalprice = a.totalprice,
                    iddetail = a.Id,
                   // price = a.price.RialToToman(),

                    productimage = _context.productRepositoryUW.GetById(a.product_id).image,
                    productname = _context.productRepositoryUW.GetById(a.product_id).title,
                    shopname = _context.shopRepositoryUW.GetById(a.shop_id).title

                });


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



     



       
    }
}
