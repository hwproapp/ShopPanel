using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class CommentApiModel
    {
        public int id { get; set; }

        public string title { get; set; }


        public string msg { get; set; }


        public string fullname { get; set; }
        public string userimage { get; set; }

       
    }
}
