using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Sell
    {

        [Key, Display(Name = "شناسه فروش ")]
        public long Id { get; set; }


        [Display(Name ="محصول ")]
        public long product_id { get; set; }


        [Display(Name = "از فروشگاه موردنظر ")]
        public long shop_id { get; set; }


        [Display(Name = "فروشنده فروشگاه ")]
        public long seller_id { get; set; }


        [Display(Name = "خرید مربوط ")]
        public long buy_id { get; set; }


        [Display(Name = "قیمت محصول ")]
        public int price { get; set; }


        [Display(Name = "تعداد ")]
        public int qty { get; set; }


        [Display(Name = " مجموع فروش محصول")]
        public long totalsellprice { get; set; }


        [Display(Name = "مجموع  فروش ")]
        public long totalprice { get; set; } // with postprice 


        [Display(Name = "قابل برداشت")]
        public long removableprice { get; set; } 



        [Display(Name = "وضیعت فروش ")]
        public byte sellstatus { get; set; }

        public bool isenable { get; set; }

        
        public DateTime createdateml { get; set; }


        [Display(Name = "تاریخ فروش")]
        public string createdatesh { get; set; }



        
        //nav 

        [ForeignKey(nameof(shop_id))]
        public virtual Shop Tbl_Shop { get; set; }


        [ForeignKey(nameof(buy_id))]
        public virtual Buy Tbl_Buy { get; set; }


        [ForeignKey(nameof(seller_id))]
        public virtual Salsman Tbl_Salsman { get; set; }
        

        [ForeignKey(nameof(product_id))]
        public virtual Product Tbl_Product { get; set; }

    }
}
