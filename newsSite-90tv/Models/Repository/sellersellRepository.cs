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
    public class sellersellRepository : Isellersell
    {
        private readonly IUnitOfWork _context;
        private readonly IAthenticate _athenticate;

        public sellersellRepository(IUnitOfWork context , IAthenticate athenticate)
        {
            _context = context;
            _athenticate = athenticate;
        }


       
        public async Task<SellerSellListApiObject> GetSellerSellList(int state , int page , string token)
        {
            var api = new SellerSellListApiObject();


            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    api.selllist = _context.sellersellRepositoryUW.Get(a => a.isenable && a.appuser_id == user.Id && a.sellstate == state, a => a.OrderByDescending(b => b.createdateml), "Tbl_OrderDetail").Select(a => new apimodels.SellerSellListApiModel
                    {
                        idproduct = a.Tbl_OrderDetail.product_id,
                        idsell = a.Id,
                        selldate = a.createdatesh + " " + DateAndTimeShamsi.MyTime(a.createdateml),
                        sellstatus = a.sellstate,
                        productimage = _context.productRepositoryUW.GetById(a.Tbl_OrderDetail.product_id).image,
                        productname = _context.productRepositoryUW.GetById(a.Tbl_OrderDetail.product_id).title,
                        fixstatus = a.fixstate
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
            catch (Exception ex)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;

        }




        public async Task<SellerSellInfoApiObject> GetSellerSellInfo(long sellid)
        {
            var api = new SellerSellInfoApiObject();
            try
            {
                var sell = await _context.sellersellRepositoryUW.GetAsync(a => a.isenable && a.Id == sellid, "Tbl_OrderDetail");

                api.sellersellinfo = new SellerSellInfoApiModel
                {
                    color = _context.colorRepositoryUW.GetById(sell.Tbl_OrderDetail.color_id) != null ? _context.colorRepositoryUW.GetById(sell.Tbl_OrderDetail.color_id).code : "",
                    count = sell.Tbl_OrderDetail.qty,
                    price = sell.Tbl_OrderDetail.totalprice.RialToToman()
                    
                };

                var idaddress = _context.OrderRepositoryUW.Get(a => a.isEnable && a.isfinish && a.Id == sell.Tbl_OrderDetail.order_id).FirstOrDefault().useradd_id;

                var address = await _context.useraddRepositoryUW.GetAsync(a => a.isenable && a.Id == idaddress, "Tbl_ostan,Tbl_city");

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


        public async Task<AllApi> SetSellingStatus(long sellid , string token)
        {
            var api = new AllApi();

            try
            {

                var user = await _athenticate.checkToken(token);
                if (user != null)
                {
                    var sellersell = await _context.sellersellRepositoryUW.GetByIdAsync(sellid);

                    sellersell.sellstate = 1; // is selling product

                    _context.sellersellRepositoryUW.Update(sellersell);

                    await _context.saveAsync();

                    //...............
                    var userbuy = await _context.userbuyRepositoryUW.GetAsync(a=>a.orderdetail_id == sellersell.orderdetail_id && a.isenable);

                    userbuy.buystate = 1; // is buying product

                    _context.userbuyRepositoryUW.Update(userbuy);

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
