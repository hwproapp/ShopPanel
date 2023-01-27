using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class CreateproductViewModel
    {
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<ProductBrand> brands { get; set; }
        public IEnumerable<Color> colors { get; set; }
        public Product product { get; set; }
        public IEnumerable<Shop> shops { get; set; }


    }
}
