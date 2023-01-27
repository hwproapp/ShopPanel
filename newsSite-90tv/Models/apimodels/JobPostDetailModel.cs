using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class JobPostDetailModel : JobPostsApiModel
    {
      
        // post detail 
        public string desc { get; set; }

        // about shop 


        public long shopid { get; set; }

        public string shopname { get; set; }

        public string shopdesc { get; set; }

        public bool shopstate { get; set; }

        public string ostan { get; set; }

        public string city { get; set; }

        public string shopcat { get; set; }

        public int followcount { get; set; }

        public string shopimage { get; set; }


        public string sellerfullname { get; set; }

        public string phone { get; set; }

        public string sellerimage { get; set; }

        public string address { get; set; }




    }
}
