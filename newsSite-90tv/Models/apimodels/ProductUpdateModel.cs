using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class ProductUpdateModel : ProductCreateModel
    {


        public long productId { get; set; }

        public List<string> trashImages { get; set; }

    }



}
