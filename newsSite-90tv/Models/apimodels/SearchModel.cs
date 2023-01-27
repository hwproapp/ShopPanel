using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class SearchModel
    {
        public int page { get; set; } = 1;
        public string value { get; set; }
    }
}
