using newsSite90tv.Models.apimodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apiobject
{
    public class CreateProductGetApiObject : AllApi
    {

        public IEnumerable<Category> categories { get; set; }

        public IEnumerable<Color> colors { get; set; }

        public IEnumerable<ProductBrand> brands { get; set; }
    }
}
