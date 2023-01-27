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
    public class userbuyRepository : Iuserbuy
    {

        private readonly IUnitOfWork _context;
        private readonly IAthenticate _athenticate;

        public userbuyRepository(IUnitOfWork context , IAthenticate athenticate)
        {
            _context = context;
            _athenticate = athenticate;
        }



        public async Task<UserBuyListApiObject> GetUserBuylist(int state, int page, string token)
        {
            var api = new UserBuyListApiObject();
            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    int paresh = (page - 1) * 10;

                   api.buylist =  _context.userbuyRepositoryUW.Get(a => a.isenable && a.appuser_id == user.Id  &&a.buystate == state, null, "Tbl_OrderDetail").Skip(paresh).Take(10).Select(a => new UserBuyListApiModel
                    {

                        idbuy = a.Id,
                        idproduct = a.Tbl_OrderDetail.product_id,
                        productimage = _context.productRepositoryUW.GetById(a.Tbl_OrderDetail.product_id).image,
                        productname = _context.productRepositoryUW.GetById(a.Tbl_OrderDetail.product_id).title,
                        shopname = _context.shopRepositoryUW.GetById(a.Tbl_OrderDetail.shop_id).title,
                        buystate = a.buystate,

                        buydate = a.createdatesh +" "+ DateAndTimeShamsi.MyTime(a.createdateml)

                    });

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

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }


        public async Task<UserBuyInfoApiObject> GetUserBuyInfo(long buyid)
        {
            var api = new UserBuyInfoApiObject();
            try
            {
                var buy = await  _context.userbuyRepositoryUW.GetAsync(a => a.isenable && a.Id == buyid, "Tbl_OrderDetail");

                api.userbuyinfo = new UserBuyDetailApiModel
                {
                    color = _context.colorRepositoryUW.GetById(buy.Tbl_OrderDetail.color_id) != null ? _context.colorRepositoryUW.GetById(buy.Tbl_OrderDetail.color_id).code : "",
                    count = buy.Tbl_OrderDetail.qty,
                    totalprice = buy.Tbl_OrderDetail.totalprice.RialToToman(),
                };

                var idaddress = _context.OrderRepositoryUW.Get(a => a.isEnable && a.isfinish && a.Id == buy.Tbl_OrderDetail.order_id).FirstOrDefault().useradd_id;

                var address =await _context.useraddRepositoryUW.GetAsync(a => a.isenable && a.Id == idaddress,"Tbl_ostan,Tbl_city");

                api.useraddress = new UserAddressListApiModel
                {
                    address = address.address,
                    cityname = address.Tbl_city.title,
                    mobile = address.mobile,
                    name = address.name,
                    ostanname = address.Tbl_ostan.title,
                    phone = address.phone
                };


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




        public async Task<AllApi> SetBuyDeliverStatus(long buyid, string token)
        {
            var api = new AllApi();

            try
            {

                var user = await _athenticate.checkToken(token);
                if (user != null)
                {
                    var userBuy = await _context.userbuyRepositoryUW.GetByIdAsync(buyid);

                    userBuy.buystate = 2; // buy complete

                    _context.userbuyRepositoryUW.Update(userBuy);

                    await _context.saveAsync();


                    // ****************  should minus count of product by 1 ****************

                    //...............
                    var sellersell = await _context.sellersellRepositoryUW.GetAsync(a => a.orderdetail_id == userBuy.orderdetail_id && a.isenable);

                    sellersell.sellstate = 2; //product sell success

                    _context.sellersellRepositoryUW.Update(sellersell);

                    await _context.saveAsync();


                    api.message = EndPointMessage.SUCCESS_MSG;
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
                api.message = EndPointMessage.API_Fail_MSG;
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }




    }
}
