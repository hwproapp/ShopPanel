using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface Iuseralarm 
    {

        Task<UserAlarmApiObject> Getuseralarm(string token, int page);
        Task<AllApi> SetReadUseralarm(string token, int id);

    }
}
