using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class SizeDetailViewModel
    {
        public Size size { get; set; }

        public IEnumerable<string> category { get; set; }
    }
}
