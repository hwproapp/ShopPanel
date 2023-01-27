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
    public class useralarmRepository : Iuseralarm
    {

        private readonly IUnitOfWork _context;
        private readonly IAthenticate _athenticate;

        public useralarmRepository(IUnitOfWork context , IAthenticate athenticate)
        {
            _context = context;
            _athenticate = athenticate;
        }
        

        public async Task<UserAlarmApiObject> Getuseralarm(string token,int page)
        {
            var api = new UserAlarmApiObject();

            try
            {

                int paresh = (page -1) * 10;

                var user =await _athenticate.checkToken(token);

                if (user != null)
                {
                    api.userAlarms = _context.useralarmRepositoryUW.Get(a => a.isenable && a.appuser_id == user.Id, a => a.OrderByDescending(b => b.status == 0)).Skip(paresh).Take(10).Select(a=>new apimodels.UserAlarmApiModel
                    {
                         body = a.body,
                         createdate = a.dateShamsi,
                         id = a.Id,
                         status = a.status,
                         title = a.title,
                         createtime = DateAndTimeShamsi.MyTime(a.dateMiladi)
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

                api.message = EndPointMessage.API_ERROR_MSG ;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }




        public async Task<AllApi> SetReadUseralarm(string token, int id)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);

                if (user!=null)
                {
                    var alarm =  await _context.useralarmRepositoryUW.GetAsync(a=>a.Id == id && a.appuser_id  == user.Id);
                    if (alarm.status == 0)
                    {
                        alarm.status = 1;
                        _context.useralarmRepositoryUW.Update(alarm);

                        await _context.saveAsync();
                    }

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

                api.status = EndPointMessage.API_ERROR_Std;
                api.message = EndPointMessage.API_ERROR_MSG;
            }

            return api;
        }
    }
}
