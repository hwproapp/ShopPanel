using newsSite90tv.Models.Services;
using newsSite90tv.Models.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Repository
{
    public class userappRepository : IUserapp
    {
        private readonly IUnitOfWork _context;

        public userappRepository(IUnitOfWork context)
        {
            _context = context;
        }

        
        public async Task<string> getfullname(long id)
        {
            var user = await _context.userappRepositoryUW.GetByIdAsync(id);

            return $"{user.firstName}  {user.lastName}";
        }

  

        public async Task<UserApp> IsUserappExist(string mobile)
        {
            return await _context.userappRepositoryUW.GetAsync(a => a.mobile == mobile);
        }






       

        public async Task<string> getfullnameseller(long id)
        {
            var user = await _context.userappRepositoryUW.GetByIdAsync(id);

            return $"{user.firstName}  {user.lastName}";
        }
    }
}
