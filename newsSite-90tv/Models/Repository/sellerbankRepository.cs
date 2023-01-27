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
    public class sellerbankRepository  : ISellerbank
    {
        private readonly IUnitOfWork _context;
        private readonly IAthenticate _athenticate;


        public sellerbankRepository(IUnitOfWork context , IAthenticate athenticate)
        {
            _context = context;
            _athenticate = athenticate;
        }


        // insert
        public  async Task<AllApi> AddBankAccount(SellerBankAddApiModel model , string token)
        {
            var api = new AllApi();
            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    var sellerid = _context.salsmanRepositoryUW.Get(a=>a.appuser_id == user.Id && a.isEnable && a.status ==1).FirstOrDefault().Id;

                    sellerBank sellerBank = new sellerBank
                    {
                        owner = model.owner,
                        status = 1,
                        bankname = model.bankName,
                        BankNom = model.bankNom,
                        shabNom = model.shabaNom,
                        isenable = true,
                        seller_id = sellerid,
                       
                    };

                    _context.sellerBankRepositoryUW.Create(sellerBank);
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


        // view

        public async Task<SellerBankListApiObject> GetSellerBank(string token)
        {
            var api = new SellerBankListApiObject();
            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {

                     var sellerid = _context.salsmanRepositoryUW.Get(a => a.appuser_id == user.Id && a.isEnable && a.status == 1).FirstOrDefault().Id;

                       api.banklist = _context.sellerBankRepositoryUW.Get(a => a.seller_id == sellerid && a.isenable && a.status ==1).Select(a=>new SellerBankListApiModel
                       {
                           bankName = a.bankname,
                           bankNom =  a.BankNom,
                           id = a.Id,
                           owner = a.owner,
                           shabaNom = "IR"+ a.shabNom
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


        // update
        public async Task<AllApi> EditSellerBank(SellerBankEditApiModel editmodel , string token)
        {
            var api = new AllApi();
            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    var sellerbank = await _context.sellerBankRepositoryUW.GetByIdAsync(editmodel.id);

                    sellerbank.bankname = editmodel.bankName;
                    sellerbank.owner = editmodel.owner;
                    sellerbank.BankNom = editmodel.bankNom;
                    sellerbank.shabNom = editmodel.shabaNom;
                    
                    _context.sellerBankRepositoryUW.Update(sellerbank);
                    await _context.saveAsync();


                    api.message = EndPointMessage.SUCCESS_Edit_MSG;
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


        // delete 

        public async Task<AllApi> DeleteSellerBank(long id, string token)
        {
            var api = new AllApi();
            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {


                   var sellerbank = await  _context.sellerBankRepositoryUW.GetByIdAsync(id);

                    sellerbank.isenable = false;

                    _context.sellerBankRepositoryUW.Update(sellerbank);

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


        // get one 

        public async Task<SellerBankListApiObject> GetSellerbanksingle(long id , string token)
        {
            var api = new SellerBankListApiObject();

            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    api.banklist = _context.sellerBankRepositoryUW.Get(a => a.Id == id,null).Select(a=>new SellerBankListApiModel
                    {
                        bankName= a.bankname,
                        bankNom = a.BankNom,
                        id = a.Id,
                        owner = a.owner,
                        shabaNom =a.shabNom
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

    }
}
