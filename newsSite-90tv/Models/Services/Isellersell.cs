using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface Isellersell 
    {
        Task<SellerSellListApiObject> GetSellerSellList(int state, int page, string token);
        Task<SellerSellInfoApiObject> GetSellerSellInfo(long sellid);
        Task<AllApi> SetSellingStatus(long sellid , string token);
    }
}
