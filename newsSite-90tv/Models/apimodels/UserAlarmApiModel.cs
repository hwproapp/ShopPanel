using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class UserAlarmApiModel
    {
        public long id { get; set; }

        public string title { get; set; }

        public string body { get; set; }

        public byte status { get; set; }


        public string createtime { get; set; }
        public string createdate { get; set; }
    }
}
