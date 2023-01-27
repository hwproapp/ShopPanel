using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ErrorReportShop:BaseClass
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "فروشگاه")]
        public long shop_id { get; set; }


        [Display(Name = "کاربر درخواست دهنده")]
        public long appuser_id { get; set; }


        [Display(Name = "دلیل تخلف")]
        public int reason_id { get; set; }



        [Display(Name ="توضیحات")]
        public string message { get; set; }


        public bool  isenable { get; set; }




        [ForeignKey("shop_id")]
        public virtual Shop Tbl_Shop { get; set; }

        [ForeignKey("appuser_id")]
        public virtual UserApp Tbl_UserApp { get; set; }


        [ForeignKey("reason_id")]
        public virtual ReportReason Tbl_Reason { get; set; }
    }
}
