using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface Iuseraddress 
    {

        Task<AllApi> AddAddress(AdduserAddressApiModel model , string token);
        Task<UserAddressApiObject> GetUserAddressList(string token);
        Task<AllApi> DeleteUserAdd(int id , string token);
    }
}
