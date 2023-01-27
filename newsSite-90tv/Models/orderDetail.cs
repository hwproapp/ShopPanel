using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class orderDetail
    {
        [Key]
        public long Id { get; set; }


        [Display(Name = "سفارش مربوط")]
        public long order_id { get; set; }


        [Display(Name = "محصول")]
        public long product_id { get; set; }


        [Display(Name = "فروشگاه مورد نظر")]
        public long shop_id { get; set; }


        [Display(Name = "تعداد")]
        public int qty { get; set; }


        [Display(Name = "رنگ")]
        public int color_id { get; set; } // may be no color



        [Display(Name = "اندازه")]
        public int size_id { get; set; } // may be no size


        [Display(Name = "قیمت")]
        public int price { get; set; }


        [Display(Name = "قیمت کل ")]
        public int totalprice { get; set; }


       
        public bool isenable { get; set; }



       





        [ForeignKey("order_id")]
        public virtual Order Tbl_Order { get; set; }


        [ForeignKey("product_id")]
        public virtual Product Tbl_Product { get; set; }



        [ForeignKey("shop_id")]
        public virtual Shop Tbl_Shop { get; set; }


    }
}
