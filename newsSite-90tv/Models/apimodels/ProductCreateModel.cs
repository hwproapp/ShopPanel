using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class ProductCreateModel
    {
      
        public long shopId { get; set; }

        public string indexImage { get; set; }

        public string title { get; set; }

        public string summary { get; set; }

        public string desc { get; set; }

        public int categoryId { get; set; }

        public int brandId { get; set; }


        public string colorId { get; set; }
        public string sizeId { get; set; }

        public string propertyId { get; set; }

        public long price { get; set; }

        public int offpercent { get; set; }

        public int weight { get; set; }

        public string garanty { get; set; }

        public int qty { get; set; }

        public List<string> gallaryImages { get; set; }
        
    }


 

}
