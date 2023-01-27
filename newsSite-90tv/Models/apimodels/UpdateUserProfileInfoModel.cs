using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class UpdateUserProfileInfoModel
    {
        public long appuser_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public string nationalcode { get; set; }

        public string mobile { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public byte gender { get; set; }

        public string image { get; set; }
    }
}
