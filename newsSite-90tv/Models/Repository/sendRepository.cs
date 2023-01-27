using newsSite90tv.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Repository
{
    public class sendRepository : Isend
    {
        public async Task<bool> sendMessage(string val, string phone)
        {
            //try
            //{
            //    Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi("api-key");
            //    var result = await api.Send("sender", phone, val);

            //    return true;

            //}
            //catch
            //{
            //    return false;
            //}

            return true;
            
        }
    }
}
