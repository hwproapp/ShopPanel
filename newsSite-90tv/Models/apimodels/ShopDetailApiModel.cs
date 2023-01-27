using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.apimodels
{
    public class ShopDetailApiModel
    {
        public string ostan { get; set; }

        public string city { get; set; }
        
        public string address { get; set; }

        public int sendcount { get; set; }

        public long sendprice { get; set; }


        public string summary { get; set; }



        // seller 

        public long sellerid { get; set; }

        public string phone { get; set; }

        public string profileseller { get; set; }

        public string sellerbio { get; set; }

        public byte gender { get; set; }

        public int shopcount { get; set; }

        public string sellername { get; set; }


    }

    public class ShopDetailsingleModel
    {
        public string ostan { get; set; }

        public string category { get; set; }

        public int productcount { get; set; }

        public string shopname { get; set; }

        public string image { get; set; }

        public string city { get; set; }

        public string address { get; set; }


        public int viewcount { get; set; }

        public int followcount { get; set; }


        public string summary { get; set; }
    }


    public class ShopInfoApiModel
    {
       // public string summary { get; set; }

        public string address { get; set; }

        public string ostan { get; set; }

        public string city { get; set; }

        public string lat { get; set; }

        public string lot { get; set; }


        public string sellername { get; set; }

        public long sellerid { get; set; }

        public string sellerimage { get; set; }
        public string sellerphone { get; set; }
    }


    public class ShopInfoApiObject  : AllApi
    {
        public ShopInfoApiModel shopinfo { get; set; }
    }
}
