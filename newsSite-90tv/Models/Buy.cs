using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Buy
    {

        [Key]
        public long Id { get; set; }



        [Display(Name ="خریدار")]
        public long buyer_id { get; set; } // user buyer


        [Display(Name = "محصول خریداری شده")]
        public long product_id { get; set; }


        [Display(Name = "  از فروشگاه مورد نظر")]
        public long shop_id { get; set; }


        [Display(Name = "ادرس خریدار")]
        public int buyeradd_id { get; set; } // user buyer address

        [Display(Name = "تعداد")]
        public int qty { get; set; }


        [Display(Name = "رنگ انتخابی")]
        public int color_id { get; set; }


        [Display(Name = "اندازه انتخابی")]
        public int size_id { get; set; }


        [Display(Name = "  قیمت محصول")]
        public int price { get; set; }

        [Display(Name = "کل قیمت خرید")]
        public int totalprice { get; set; }

        [Display(Name = "نوع ارسال پست")]
        public byte posttype { get; set; }

       


        [Display(Name = "وضیعت خرید")]
        public byte buystatus { get; set; }


      
        public DateTime createdateml { get; set; }


        [Display(Name = "تاریخ خرید")]
        public string createdatesh { get; set; }

        public bool isenable { get; set; }


        //nav 


        [ForeignKey(nameof(shop_id))]
        public virtual Shop Tbl_Shop { get; set; }

        [ForeignKey(nameof(buyer_id))]
        public virtual UserApp Tbl_UserApp { get; set; }

        [ForeignKey(nameof(product_id))]
        public virtual Product Tbl_Product { get; set; }

        [ForeignKey(nameof(buyeradd_id))]
        public virtual UserAddress Tbl_UserAddress { get; set; }
    }


}
