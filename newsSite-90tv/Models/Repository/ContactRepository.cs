using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Repository
{
    public class ContactRepository : Icontact
    {
        private readonly IUnitOfWork _context;
        private readonly IAthenticate _athenticate;


        public ContactRepository(IUnitOfWork context, IAthenticate athenticate)
        {
            _context = context;
            _athenticate = athenticate;
        }



        
        public async Task<AllApi> addcontact(string token, ContactApiModel contactmodel)
        {
            var api = new AllApi();

            try
            {
                var user = await  _athenticate.checkToken(token);

                if (user != null)
                {

                    var newcontact = new ContactUs
                    {
                        appuser_id = user.Id,
                        body = contactmodel.desc,
                        status = contactstate.unread.ToByte(),
                        isenable = true,
                        title = contactmodel.title,
                        
                        
                        
                    };

                    _context.ContactRepositoryUW.Create(newcontact);
                    await _context.saveAsync();



                    api.message = EndPointMessage.API_SUCCESS_MSG;
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
