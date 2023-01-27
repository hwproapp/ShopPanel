using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class JobCategoryApiModel
    {
       


        public int id { get; set; }
        public string  title { get; set; }
        public int productcount { get; set; }

        public string image { get; set; }

        public int subid { get; set; }

        public int type { get; set; }
    }
}
