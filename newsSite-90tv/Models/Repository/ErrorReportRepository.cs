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
    public class ErrorReportRepository : IReport
    {
        private readonly IUnitOfWork _context;
        private readonly IAthenticate _athenticate;

        public ErrorReportRepository(IUnitOfWork context , IAthenticate athenticate)
        {
            _context = context;
            _athenticate = athenticate;
        }

        public async Task<AllApi> AddProductReport(ErrorReportApiModel model, string token)
        {
            var api = new AllApi();
            try
            {
                var user  = await _athenticate.checkToken(token);

                if (user == null)
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }
                else
                {
                    var count_exist = await  _context.ReportProductRepositoryUW.GetManyAsync(a => a.product_id == model.id && a.appuser_id == user.Id);

                    if (count_exist != null &&  count_exist.Count() == 3)
                    {
                        api.message = EndPointMessage.API_CREATE_REPORT_LIMIT;
                        api.status = EndPointMessage.API_Token_FAIL_Std;
                    }
                    else
                    {
                        ReportProduct errorReport = new ReportProduct
                        {
                            appuser_id = user.Id,
                            isenable = true,
                            status = Status.suspend.ToByte(), // not check
                            reason_id = model.reason_id,
                            product_id = model.id,
                            message = model.desc,

                        };


                        _context.ReportProductRepositoryUW.Create(errorReport);
                        await _context.saveAsync();


                        api.message = EndPointMessage.API_CREATE_REPORT;
                        api.status = EndPointMessage.API_OK_Std;
                    }

                }


            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_Fail_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }

        public async Task<AllApi> AddshopReport(ErrorReportApiModel model, string token)
        {
            var api = new AllApi();
            try
            {
                var user =await _athenticate.checkToken(token);

                if (user == null)
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }
                else
                {
                    var count_exist =await _context.ReportShopRepositoryUW.GetManyAsync(a => a.shop_id == model.id && a.appuser_id == user.Id);

                    if (count_exist != null &&  count_exist.Count() == 3)
                    {
                        api.message = EndPointMessage.API_CREATE_REPORT_SHOP_LIMIT;
                        api.status = EndPointMessage.API_Token_FAIL_Std;
                    }
                    else
                    {
                        ErrorReportShop errorReport = new ErrorReportShop
                        {
                            appuser_id = user.Id,
                            isenable = true,
                            status = 0,
                            reason_id = model.reason_id,
                            shop_id = model.id,
                            message = model.desc,

                        };


                        _context.ReportShopRepositoryUW.Create(errorReport);
                        await _context.saveAsync();


                        api.message = EndPointMessage.API_CREATE_REPORT;
                        api.status = EndPointMessage.API_OK_Std;
                    }

                }


            }
            catch (Exception ex)
            {

                api.message = EndPointMessage.API_ERROR_MSG + ex.Message;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }



        public async Task<ReportReasonListApiObject> GetReasonList(int type)
        {
            var api = new ReportReasonListApiObject();
            try
            {
                api.ReportReasons = await _context.ReportReasonRepositoryUW.GetManyAsync(a => a.isenable);

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
