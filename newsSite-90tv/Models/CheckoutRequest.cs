using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class CheckoutRequest : BaseClass
    {

        [Key , Display(Name ="شناسه")]
        public long Id { get; set; }

        [Display(Name = "فروشگاه درخواست دهنده")]
        public long shop_id { get; set; }

        [Display(Name = "فروشنده درخواست دهنده")]
        public long seller_id { get; set; }

     
        public long bank_id { get; set; }


        [Display(Name = "درخواست برداشت")]
        public int requestprice { get; set; }
        



        //nav

        [ForeignKey(nameof(shop_id))]
        public virtual Shop Tbl_Shop { get; set; }

        
        [ForeignKey(nameof(seller_id))]
        public virtual Salsman Tbl_Salsman { get; set; }


        [ForeignKey(nameof(bank_id))]
        public virtual sellerBank Tbl_sellerbank { get; set; }

    }
}
