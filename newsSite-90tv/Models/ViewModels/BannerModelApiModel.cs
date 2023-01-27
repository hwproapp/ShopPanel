using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class BannerDetailsViewModel
    {
        public workerBanner banner { get; set; }
        public IEnumerable<bannerImage> bannerimage { get; set; }
    }
}
