using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface Ideleteimage 
    {
      
        Task<bool> DeleteImageHost(string imagename, string path1, string path2 = "" , string filter="");
    }
}
