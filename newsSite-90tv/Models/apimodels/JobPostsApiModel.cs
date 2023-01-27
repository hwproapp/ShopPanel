using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class JobPostsApiModel
    {
        public long id { get; set; }

        public string title { get; set; }

        public string cattitle { get; set; }

        public string tagtitle { get; set; }

        public int  tagtype { get; set; }

        public string time { get; set; }

        public int viewcount { get; set; }

    }
}
