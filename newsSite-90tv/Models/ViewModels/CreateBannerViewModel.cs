using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class CreateBannerViewModel
    {

        public IEnumerable<AppUserDropDownViewModel> appusers { get; set; }

        public IEnumerable<Ostan> ostan { get; set; }

        public IEnumerable<Category> category { get; set; }

        public workerBanner banner { get; set; }

        public IEnumerable<City> city { get; set; }
    }
}
