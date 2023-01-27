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
    public class favRepository : Ifav
    {
        private readonly IUnitOfWork _context;
        private readonly IAthenticate _athenticate;


        public favRepository(IUnitOfWork context , IAthenticate athenticate)
        {
            _context = context;
            _athenticate = athenticate;
        }

        public async Task<AllApi> DelFav(int favid ,string token)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    var favexist = await _context.favRepositoryUW.GetByIdAsync(favid);

                    if (favexist == null)
                    {
                        
                        api.message = EndPointMessage.API_Fail_MSG;
                        api.status = EndPointMessage.API_Fail_Std;
                    }
                    else
                    {
                       

                        _context.favRepositoryUW.Delete(favexist);
                        await _context.saveAsync();

                        var prod =await _context.productRepositoryUW.GetByIdAsync(favexist.product_id);
                        prod.likeCount--;
                        _context.productRepositoryUW.Update(prod);
                        await _context.saveAsync();

                        api.message = EndPointMessage.API_FAV_DELETE;
                        api.status = EndPointMessage.API_OK_Std;
                    }


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

       

        public async Task<FavListApiObject> GetFavList(int page, string token)
        {
            var api = new FavListApiObject();

            try
            {
                var user = await _athenticate.checkToken(token);
                if (user != null)
                {
                    int paresh = (page -1) * 10;

                    api.favlist = _context.favRepositoryUW.Get(a => a.appuser_id == user.Id).Skip(paresh).Take(10).Select(a => new FavListApiModel
                    {
                        idfav = a.Id,
                        idproduct = a.product_id,
                        productimage = _context.productRepositoryUW.GetById(a.product_id).image,
                        productname = _context.productRepositoryUW.GetById(a.product_id).title
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

        public async Task<AllApi> SetFav(long productid, string token)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);
               
                if (user != null)
                {
                    var favexist = await _context.favRepositoryUW.GetAsync(a => a.product_id == productid && a.appuser_id == user.Id);

                    var prod = await _context.productRepositoryUW.GetByIdAsync(productid);

                    if (favexist  ==null)
                    {
                        // set fave
                        ProductFav fav = new ProductFav
                        {
                            appuser_id = user.Id,
                            product_id = productid
                        };


                        _context.favRepositoryUW.Create(fav);
                        await _context.saveAsync();

                       
                        prod.likeCount++;
                        _context.productRepositoryUW.Update(prod);
                        await _context.saveAsync();

                        api.message = EndPointMessage.API_FAV_ADD;
                        api.status = EndPointMessage.API_OK_Std;
                    }
                    else
                    {
                        // un set fav user twice click fav btn

                        _context.favRepositoryUW.Delete(favexist);
                        await _context.saveAsync();

                      
                        prod.likeCount--;
                        _context.productRepositoryUW.Update(prod);
                        await _context.saveAsync();

                        api.message = EndPointMessage.API_FAV_DELETE;
                        api.status = EndPointMessage.API_OK_Std;
                    }


                }else
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }
            }
            catch (Exception ex)
            {

                api.message = EndPointMessage.API_Fail_MSG + ex;
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }
    }
}
