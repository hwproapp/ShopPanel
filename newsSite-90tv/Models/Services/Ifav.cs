using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface Ifav
    {
        Task<AllApi> SetFav(long productid , string token);
        Task<AllApi> DelFav(int favid, string token);

        Task<FavListApiObject> GetFavList(int page , string token);

    }
}
