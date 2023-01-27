using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using newsSite90tv.PublicClass;
using newsSite90tv.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Repository
{
    public class bannerRepository : Ibanner
    {

        private readonly IUnitOfWork _context;
        private readonly IAthenticate _athenticate;
        private readonly IsaveImage _saveimage;
        private readonly Ideleteimage _idelimage;

        public bannerRepository(IUnitOfWork context, IAthenticate userapp, IsaveImage saveImage, Ideleteimage delimage)
        {
            _context = context;
            _athenticate = userapp;
            _saveimage = saveImage;
            _idelimage = delimage;
        }

        public async Task<bannerListApiObject> Getbanners(int page)
        {
            var api = new bannerListApiObject();

            try
            {

                api.banners = _context.workerBannerRepositoryUW.Get(a => a.isenable && a.status == Status.valid.ToByte(), a => a.OrderByDescending(o => o.dateMiladi), "Tbl_Category,Tbl_City").Select(a => new bannerListApiModel
                {
                    image = a.image,
                    category = a.Tbl_Category.Title,
                    id = a.Id,
                    time = Utility.bannertime(a.dateMiladi),
                    title = a.title,
                    viewcount = a.viewcount,
                    city = a.Tbl_City.title,
                    desc = a.desc,


                });


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




        public async Task<bannerListApiObject> Getbannersbytitle(string title, int cityid, int catid, int page)
        {
            var api = new bannerListApiObject();
            try
            {

                api.banners = _context.workerBannerRepositoryUW.Get(a => a.isenable && a.status == 1 && a.title.Contains(title) , a => a.OrderByDescending(o => o.dateMiladi), "Tbl_Category,Tbl_City").Select(a => new bannerListApiModel
                {
                    image = a.image,
                    category = a.Tbl_Category.Title,
                    id = a.Id,
                    time = Utility.bannertime(a.dateMiladi),
                    title = a.title,
                    viewcount = a.viewcount,
                    city = a.Tbl_City.title,
                    desc = a.desc,

                });


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



        public async Task<bannerInfoApiObject> Getbannerinfo(long bannerId)
        {
            var api = new bannerInfoApiObject();
            try
            {
                // set viewcount of banner
                var banner = await _context.workerBannerRepositoryUW.GetAsync(a=>a.Id == bannerId && a.isenable && a.status == 1, "Tbl_Category,Tbl_City,Tbl_UserApp");

                 banner.viewcount++;

                _context.workerBannerRepositoryUW.Update(banner);

                await _context.saveAsync();



                // banner info 

                api.bannerdetail = new bannerInfoApiModel

                {
                    desc = banner.desc,
                    title = banner.title,
                    category = banner.Tbl_Category.Title,
                    city = banner.Tbl_City.title,
                    mobile = banner.Tbl_UserApp.mobile


                };


                // banner images
                api.images = _context.bannerimagesRepositoryUW.Get(a => a.banner_id == bannerId).Select(a => a.image);




                // same banner
                api.samebanner = _context.workerBannerRepositoryUW.Get(a => a.isenable && a.status == 1 && a.Id != bannerId && a.category_id == banner.category_id, null, "Tbl_Category,Tbl_City").Take(10).Select(a => new bannerListApiModel
                {
                    image = a.image,
                    category = a.Tbl_Category.Title,
                    id = a.Id,
                    time = Utility.bannertime(a.dateMiladi),
                    title = a.title,
                    viewcount = a.viewcount,
                    city = a.Tbl_City.title,
                    desc = a.desc,

                });

              
                



                api.message = EndPointMessage.API_OK_MSG;
                api.status = EndPointMessage.API_OK_Std;
            }
            catch (Exception ex)
            {

                api.message = EndPointMessage.API_ERROR_MSG +ex.ToString();
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }





        public async Task<AllApi> AddJobBanner(AddJobBannerApiModel banner, long appuserid)
        {
            var api = new AllApi();

            try
            {


                workerBanner newbanner = new workerBanner
                {
                    category_id = banner.cat_id,
                    title = banner.title,
                    desc = banner.desc,
                    appuser_id = appuserid,
                    city_id = banner.city_id,
                    isenable = true,
                    status = Status.suspend.ToByte(),
                    viewcount = 0,
                    todate = DateTime.Now.AddMonths(1), // enable till a moonth


                };

                _context.workerBannerRepositoryUW.Create(newbanner);
                await _context.saveAsync();

                //  var bannerid = newbanner.Id;


                if (banner.images != null && banner.images.Count() != 0)
                {
                    if (banner.images.Count() > 3)
                    {
                        api.message = "شما حداکثر تا سه تصویر میتوانین برای اگهی خود ارسال کنید";
                    }
                    else
                    {
                        var listimages = banner.images;

                        foreach (var item in listimages)
                        {

                            if (!string.IsNullOrEmpty(item))
                            {
                                var path = await _saveimage.SaveJobBannerImage(Convert.FromBase64String(item));

                                _context.bannerimagesRepositoryUW.Create(new bannerImage
                                {
                                    banner_id = newbanner.Id,
                                    image = path
                                });

                                await _context.saveAsync();

                            }

                        }


                    }
                }



                api.message = EndPointMessage.API_CREATE_JOBBANNER_SUCCESS;
                api.status = EndPointMessage.API_OK_Std;

            }
            catch (Exception ex)
            {

                api.message = EndPointMessage.API_Fail_MSG;
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }




        public async Task<MyBannersApiObject> GetMyBanners(string token, int page)
        {
            var api = new MyBannersApiObject();

            try
            {

                int paresh = (page - 1) * 10;
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    api.mybanners = _context.workerBannerRepositoryUW.Get(a => a.status == 1 && a.appuser_id == user.Id, a => a.OrderByDescending(o => o.dateMiladi), "Tbl_UserApp,Tbl_Category").Skip(paresh).Take(10).Select(a => new MyBannersApiModel
                    {
                        image = a.image,
                        category = a.Tbl_Category.Title,
                        idbanner = a.Id,
                        time = Utility.bannertime(a.dateMiladi),
                        title = a.title,
                        viewcount = a.viewcount,
                        status = a.status, // true is enable else disable


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



        public async Task<DetailForBannerEditApiObject> GetbannerInfoForEdit(string token, long bannerid)
        {
            var api = new DetailForBannerEditApiObject();

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
                    api.banneredit = _context.workerBannerRepositoryUW.Get(a => a.Id == bannerid && a.appuser_id == user.Id, null, "Tbl_City").Select(a => new DetailForBannerEditApiModel
                    {
                        cat_id = a.category_id,
                        city_id = a.city_id,
                        desc = a.desc,
                        images = _context.bannerimagesRepositoryUW.Get(b => b.banner_id == a.Id).Select(s => new BannerImage
                        {
                            id = s.Id,
                            name = s.image
                        }),

                        ostan_id = a.Tbl_City.ostan_id,
                        title = a.title,

                    }).FirstOrDefault();


                    api.message = EndPointMessage.API_OK_MSG;
                    api.status = EndPointMessage.API_OK_Std;
                }


            }
            catch (Exception)
            {

                api.message = EndPointMessage.API_ERROR_MSG;
                api.status = EndPointMessage.API_ERROR_Std;
            }

            return api;
        }




        public async Task<AllApi> EditBanner(EditBannerApiModel model, string token)
        {
            var api = new AllApi();

            try
            {
                var user = _athenticate.checkToken(token);

                if (user == null)
                {
                    api.message = EndPointMessage.API_FAIL_TOKEN_MSG;
                    api.status = EndPointMessage.API_Token_FAIL_Std;
                }
                else
                {
                    var editbanner = await _context.workerBannerRepositoryUW.GetByIdAsync(model.idbanner);

                    editbanner.title = model.title;
                    editbanner.desc = model.desc;
                    editbanner.category_id = model.cat_id;
                    editbanner.city_id = model.city_id;



                    _context.workerBannerRepositoryUW.Update(editbanner);
                    await _context.saveAsync();

                    //images is new
                    if (model.images != null && model.images.Count() != 0)
                    {
                        if (model.images.Count() > 3)
                        {
                            api.message = "شما حداکثر تا سه تصویر میتوانین برای اگهی خود ارسال کنید";
                        }
                        else
                        {
                            var listimages = model.images;

                            foreach (var item in listimages)
                            {
                                if (!string.IsNullOrEmpty(item))
                                {
                                    var path = await _saveimage.SaveJobBannerImage(Convert.FromBase64String(item));

                                    _context.bannerimagesRepositoryUW.Create(new bannerImage
                                    {
                                        banner_id = model.idbanner,
                                        image = path
                                    });

                                    await _context.saveAsync();
                                }
                                else
                                {
                                    // image list empty can send error about it
                                }

                            }


                        }
                    }

                    // check if image delete
                    if (model.trashimage != null && model.trashimage.Count() != 0)
                    {
                        // yes we  should delete old image 



                        foreach (var item in model.trashimage)
                        {

                            if (item != 0)
                            {
                                var oldimage = await _context.bannerimagesRepositoryUW.GetAsync(a => a.Id == item);

                                _context.bannerimagesRepositoryUW.Delete(oldimage);
                                await _context.saveAsync();

                                await _idelimage.DeleteImageHost(oldimage.image , "upload\\banners\\normalimages\\" , "");
                            }



                        }


                    }

                    api.message = EndPointMessage.API_EDIT_JOBBANNER_SUCCESS;
                    api.status = EndPointMessage.API_OK_Std;

                }
            }
            catch (Exception ex)
            {

                api.message = EndPointMessage.API_Fail_MSG + ex.ToString();
                api.status = EndPointMessage.API_Fail_Std;
            }

            return api;
        }



        public async Task<AllApi> DeleteBanner(long id, string token)
        {
            var api = new AllApi();

            try
            {
                var user = await _athenticate.checkToken(token);

                if (user != null)
                {
                    var banner = await _context.workerBannerRepositoryUW.GetByIdAsync(id);

                    banner.isenable = false;


                    _context.workerBannerRepositoryUW.Update(banner);
                    await _context.saveAsync();


                    // delete images
                    var bannerimage = await _context.bannerimagesRepositoryUW.GetManyAsync(a => a.banner_id == id);
                    _context.bannerimagesRepositoryUW.DeleteAll(bannerimage);
                    await _context.saveAsync();

                    foreach (var item in bannerimage)
                    {


                        await _idelimage.DeleteImageHost(item.image , "upload\\banners\\normalimage\\");

                    }









                    api.message = EndPointMessage.API_DELETE_JOBBANNER_SUCCESS;
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







        /*
        public async Task<bannerListApiObject> Getbannersbycat(int catid, int page)
        {
            var api = new bannerListApiObject();

            try
            {
                int paresh = (page - 1) * 10;

                api.banners = _context.workerBannerRepositoryUW.Get(a => a.isenable && a.status == 1 && a.category_id == catid && a.todate.CompareTo(DateTime.Now) > 0, a => a.OrderByDescending(o => o.dateMiladi), "Tbl_City,Tbl_Category").Skip(paresh).Take(10).Select(a => new bannerListApiModel
                {
                    bannerimage = _context.bannerimagesRepositoryUW.Get(b => b.banner_id == a.Id).FirstOrDefault() != null ? _context.bannerimagesRepositoryUW.Get(b => b.banner_id == a.Id).FirstOrDefault().image : "defualtimage.png",
                    category = a.Tbl_Category.Title,
                    idbanner = a.Id,
                    time = Utility.bannertime(a.dateMiladi),
                    title = a.title,
                    viewcount = a.viewcount,
                    city = a.Tbl_City.title
                });

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

        public async Task<bannerListApiObject> Getbannersbycity(int cityid, int page)
        {
            var api = new bannerListApiObject();

            try
            {
                int paresh = (page  - 1) * 10;

                api.banners = _context.workerBannerRepositoryUW.Get(a => a.isenable && a.status == 1 && a.city_id == cityid && a.todate.CompareTo(DateTime.Now) > 0, a => a.OrderByDescending(o => o.dateMiladi), "Tbl_City,Tbl_Category").Skip(paresh).Take(10).Select(a => new bannerListApiModel
                {
                    bannerimage = _context.bannerimagesRepositoryUW.Get(b => b.banner_id == a.Id).FirstOrDefault() != null ? _context.bannerimagesRepositoryUW.Get(b => b.banner_id == a.Id).FirstOrDefault().image : "defualtimage.png",
                    category = a.Tbl_Category.Title,
                    idbanner = a.Id,
                    time = Utility.bannertime(a.dateMiladi),
                    title = a.title,
                    viewcount = a.viewcount,
                    city = a.Tbl_City.title
                });

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


        public async Task<bannerListApiObject> Getbannersbycityandcat(int catid , int cityid, int page)
        {
            var api = new bannerListApiObject();

            try
            {
                int paresh = (page - 1) * 10;

                api.banners = _context.workerBannerRepositoryUW.Get(a => a.isenable && a.status == 1 && a.city_id == cityid && a.category_id == catid &&  a.todate.CompareTo(DateTime.Now) > 0, a => a.OrderByDescending(o => o.dateMiladi), "Tbl_City,Tbl_Category").Skip(paresh).Take(10).Select(a => new bannerListApiModel
                {
                    bannerimage = _context.bannerimagesRepositoryUW.Get(b => b.banner_id == a.Id).FirstOrDefault() != null ? _context.bannerimagesRepositoryUW.Get(b => b.banner_id == a.Id).FirstOrDefault().image : "defualtimage.png",
                    category = a.Tbl_Category.Title,
                    idbanner = a.Id,
                    time = Utility.bannertime(a.dateMiladi),
                    title = a.title,
                    viewcount = a.viewcount,
                    city = a.Tbl_City.title
                });

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

      */


    }
}
