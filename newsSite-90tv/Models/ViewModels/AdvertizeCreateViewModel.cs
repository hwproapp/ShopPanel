using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class AdvertizeCreateViewModel
    {
        public shopadvertise adv { get; set; }
        public IEnumerable<Shop> shops { get; set; }
    }
}
