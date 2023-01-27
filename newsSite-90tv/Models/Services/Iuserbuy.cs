using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface Iuserbuy 
    {
        Task<UserBuyListApiObject> GetUserBuylist(int state , int page , string token);
        Task<UserBuyInfoApiObject> GetUserBuyInfo(long buyid);

        Task<AllApi> SetBuyDeliverStatus(long buyid, string token);
    }
}
