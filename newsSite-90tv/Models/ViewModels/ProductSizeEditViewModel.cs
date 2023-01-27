using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class ProductSizeEditViewModel
    {
        public Size size { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<int> selectedid { get; set; }
    }
}
