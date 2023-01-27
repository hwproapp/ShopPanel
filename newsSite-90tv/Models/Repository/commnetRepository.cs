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
    public class commnetRepository : Icomment
    {
        private readonly IUnitOfWork _context;
        private readonly IAthenticate _athenticate;


        public commnetRepository(IUnitOfWork context , IAthenticate athenticate)
        {
            _context = context;
            _athenticate = athenticate;
        }

        public async Task<AllApi> setproductcomment(AddCommentModel model ,string token)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    var comment = new Comment
                    {
                        body = model.body,
                        product_id = model.id,
                        appuser_id = user.Id,
                        status = Status.suspend.ToByte(), // suspent


                        isEnable = true
                        
                    };


                    _context.commentRepositoryUW.Create(comment);
                    await _context.saveAsync();



                    api.message = EndPointMessage.API_COMMENT_ADD_MSG_SUCCESS;
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
        
        public async Task<commentapiobject> getproductcomment(long id, int page)
        {
            var api = new commentapiobject();
           try
            {

                int paresh = (page - 1) * 10;

                api.comments = _context.commentRepositoryUW.Get(a => a.product_id == id && a.status == 1 && a.isEnable, null , "Tbl_UserApp").Skip(paresh).Take(10).Select(a => new CommentApiModel
                {
                    id = a.Id,
                    msg = a.body,
                    fullname = a.Tbl_UserApp.firstName + " " +a.Tbl_UserApp.lastName ,
                    userimage = a.Tbl_UserApp.image

                }).ToList();


                


                api.status = EndPointMessage.API_OK_Std;
                api.message = EndPointMessage.API_OK_MSG;

            }catch
            {
                api.status = EndPointMessage.API_ERROR_Std;
                api.message = EndPointMessage.API_ERROR_MSG;
            }

            return api;
        }




        public async Task<AllApi> setshopcomment(AddCommentModel model, string token)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    var comment = new shopcomments
                    {
                       body = model.body,
                       shop_id = model.id,
                       appuser_id  = user.Id,
                       replyto = 0,
                       status = 0,
                       
                       

                    };


                    _context.shopCommentUW.Create(comment);
                    await _context.saveAsync();



                    api.message = EndPointMessage.API_COMMENT_ADD_MSG_SUCCESS;
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

        public async Task<commentapiobject> getshopcomments(long shopid , int page)
        {
            var api = new commentapiobject();
            try
            {

                int paresh = (page - 1) * 10;

                api.comments = _context.shopCommentUW.Get(a => a.shop_id == shopid && a.status == 1 && a.IsEnable ,  null, "Tbl_UserApp").Skip(paresh).Take(10).Select(a => new CommentApiModel
                {
                    id = a.Id,
                    msg = a.body,
                    fullname = a.Tbl_UserApp.firstName + " " + a.Tbl_UserApp.lastName,
                    userimage = a.Tbl_UserApp.image

                }).ToList();





                api.status = EndPointMessage.API_OK_Std;
                api.message = EndPointMessage.API_OK_MSG;

            }
            catch
            {
                api.status = EndPointMessage.API_ERROR_Std;
                api.message = EndPointMessage.API_ERROR_MSG;
            }

            return api;
        }
    }
}
