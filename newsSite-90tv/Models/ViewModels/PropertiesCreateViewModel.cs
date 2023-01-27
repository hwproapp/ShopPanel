using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class PropertiesCreateViewModel
    {
        public Properties properties { get; set; }

        public IEnumerable<Category> categories { get; set; }
    }
}
