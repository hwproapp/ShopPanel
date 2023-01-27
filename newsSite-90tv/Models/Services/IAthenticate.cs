using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface IAthenticate
    {

        Task<UserApp> checkToken(string token);


      

        Task<AllApi> register(RegisterApiModel register);
        Task<AllApi> preregister(string phone);
        Task<AllApi> login(string phone);
        Task<AllApi> coderesend(string phone);

        Task<UserAppApiObject> verify(string code, string phone);

        Task<AllApi> updateprofile(UserAppApiModel profile, string token);


    }
}
