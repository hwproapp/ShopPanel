using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Services
{
   public interface Ibanner 
    {
        Task<bannerListApiObject> Getbanners(int page);
      
        Task<bannerInfoApiObject> Getbannerinfo(long bannerId);
        
        Task<AllApi> AddJobBanner(AddJobBannerApiModel banner, long appuserid);


        //Task<bannerListApiObject> Getbannersbycat(int catid, int page);
        //Task<bannerListApiObject> Getbannersbycityandcat(int catid, int cityid, int page);
        //Task<bannerListApiObject> Getbannersbycity(int cityid, int page);
        Task<bannerListApiObject> Getbannersbytitle(string title , int cityid ,int catid, int page);


        Task<MyBannersApiObject> GetMyBanners(string token, int page);
        Task<DetailForBannerEditApiObject> GetbannerInfoForEdit(string token, long bannerid);

  

        Task<AllApi> EditBanner(EditBannerApiModel model, string token);
        Task<AllApi> DeleteBanner(long id, string token);
    }
}
