using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface ISellerbank
    {
        Task<AllApi> AddBankAccount(SellerBankAddApiModel model, string token);
        Task<SellerBankListApiObject> GetSellerBank(string token);

        Task<AllApi> EditSellerBank(SellerBankEditApiModel editmodel, string token);

        Task<AllApi> DeleteSellerBank(long id, string token);

        Task<SellerBankListApiObject> GetSellerbanksingle(long id, string token);
    }
}
