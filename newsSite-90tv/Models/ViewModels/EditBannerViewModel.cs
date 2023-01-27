using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class EditBannerViewModel : CreateBannerViewModel
    {
        public IEnumerable<City> city { get; set; }
    }
}
