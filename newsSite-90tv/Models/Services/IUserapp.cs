using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface IUserapp 
    {
        Task<string> getfullname(long id);
        Task<UserApp> IsUserappExist(string phone);

    }
}
