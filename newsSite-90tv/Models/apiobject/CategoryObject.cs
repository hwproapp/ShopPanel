using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class CategoryObject : AllApi
    {
        public IEnumerable<Category> categories { get; set; }


        public CategoryObject()
        {
            categories = new List<Category>();
        }
        
    }

  
}


