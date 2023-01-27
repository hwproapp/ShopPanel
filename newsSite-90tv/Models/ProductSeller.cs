using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ProductSeller : BaseClass
    {

        [Key]
        public long Id { get; set; }


        [Display(Name = "محصول")]
        public long product_id { get; set; }

        [Display(Name ="فروشگاه")]
        public long shop_id { get; set; }

        
        [Display(Name = "فروشنده")]
        public long seller_id { get; set; }


        [Display(Name = "قیمت")]
      
        public long price { get; set; }


        [Display(Name = "تخفیف %")]
        public byte offpercent { get; set; }


        [Display(Name = "تعداد")]
        public byte qty { get; set; }


        [Display(Name = "وضیعت موجود بودن محصول")]
        public bool isExist { get; set; }


        [Display(Name = "مالکیت فروشنده")]
        public bool ismainseller { get; set; }

        public byte productType { get; set; }


        public bool isEnable { get; set; }
        

        //nav

        [ForeignKey("seller_id")]
        public virtual Salsman Tbl_Salsman { get; set; }

        [ForeignKey("shop_id")]
        public virtual Shop Tbl_Shop { get; set; }

        [ForeignKey("product_id")]

        public virtual Product Tbl_Product { get; set; }


    }
}
