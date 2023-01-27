using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
   public  interface Isend
    {
        Task<bool> sendMessage(string val , string phone);
    }
}
