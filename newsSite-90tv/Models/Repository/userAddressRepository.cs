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
    public class userAddressRepository : Iuseraddress
    {
        private readonly IUnitOfWork _context;
        private readonly IAthenticate _athenticate;

        public userAddressRepository(IUnitOfWork context , IAthenticate athenticate)
        {
            _context = context;
            _athenticate = athenticate;
        }

        public async Task<AllApi> AddAddress(AdduserAddressApiModel model, string token)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);
                if (user != null)
                {

                    UserAddress newadd = new UserAddress
                    {
                        address = model.address,
                        appuser_id = user.Id,
                        isenable = true,
                        postalcode = model.postalcode,
                        city_id = model.city_id,
                        ostan_id = model.ostan_id,
                        lat = model.lat,
                        lot = model.lot,
                        mobile = model.mobile,
                        name = model.name,
                        phone = model.phone,
                        dateshamsi = DateAndTimeShamsi.DateTimeShamsi(),
                        datemiladi = DateTime.Now
                    };

                    _context.useraddRepositoryUW.Create(newadd);
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

    
        

        public async Task<UserAddressApiObject> GetUserAddressList(string token)
        {
            var api = new UserAddressApiObject();

            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    api.address = _context.useraddRepositoryUW.Get(a => a.isenable && a.appuser_id == user.Id, a=>a.OrderByDescending(b=>b.datemiladi), "Tbl_ostan,Tbl_city").Select(a => new UserAddressListApiModel
                    {
                        address = a.address,
                        cityname = a.Tbl_city.title,
                        ostanname = a.Tbl_ostan.title,
                        id = a.Id,
                        mobile = a.mobile,
                        name = a.name,
                        phone = a.phone

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


        public async  Task<AllApi> DeleteUserAdd(int id, string token)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);
                if (user!= null)
                {

                    var address = await _context.useraddRepositoryUW.GetAsync(a => a.appuser_id == user.Id && a.Id == id);

                    address.isenable = false;

                    _context.useraddRepositoryUW.Update(address);

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

                api.message = EndPointMessage.API_Fail_MSG;
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }



        
    }
}
