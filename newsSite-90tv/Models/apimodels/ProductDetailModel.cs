using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class ProductDetailModel 
    {

        public long id { get; set; }
        public string title { get; set; }


        public string summary { get; set; }

        public string desc { get; set; }

        public string brand { get; set; }
        
        public string cat { get; set; }

   

        public string shopname { get; set; }

        public long shopid { get; set; }



        public string image { get; set; }


        public int viewcount { get; set; }

        public int likecount { get; set; }
        
        public long price { get; set; }

      
        public int offpercent { get; set; }


        public bool isexist { get; set; }



        public string garanty { get; set; }


    }





}
