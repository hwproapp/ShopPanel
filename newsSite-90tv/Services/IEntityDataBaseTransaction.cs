using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Services
{
   public interface IEntityDataBaseTransaction : IDisposable
    {
        void Commit();
        void RollBack();
    }
}
