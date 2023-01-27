using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class AdduserAddressApiModel
    {
        public string name { get; set; }

        public string address { get; set; }

        public string postalcode { get; set; }

        public string phone { get; set; }

        public string mobile { get; set; }

        public int city_id { get; set; }

        public int ostan_id { get; set; }

        public string lat { get; set; }

        public string lot { get; set; }
    }
}
