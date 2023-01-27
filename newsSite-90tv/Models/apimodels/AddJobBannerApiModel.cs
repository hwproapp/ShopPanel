using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class AddJobBannerApiModel
    {
        

        public string title { get; set; }

        public string desc { get; set; }

        public int cat_id { get; set; }

        public int city_id { get; set; }
        

        public IEnumerable<string> images { get; set; }


    }

    
}
