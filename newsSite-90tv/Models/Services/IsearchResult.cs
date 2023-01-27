using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface IsearchResult : IDisposable
    {
        Hashtable SearchResProd(byte order , string key ,int page  , byte take);
        Hashtable SearchResShop(byte order , string key ,int page, byte take);
        Hashtable SearchResSeller(byte order , string key ,int page, byte take);
        Hashtable SearchResuserApp(byte order , string key ,int page, byte take);
    
        Hashtable SearchResadv(string key ,int page, byte take);
    }

    public enum pagingTake
    {
        five = 5,
        ten  = 10,
        fifteen  = 15,
        twenty = 20
    }
}
