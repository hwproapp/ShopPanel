
using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ReportProduct : BaseClass
    {
        [Key]
        public int Id { get; set; }
    

        [Display(Name ="محصول")]
        public long product_id { get; set; }


        [Display(Name ="کاربر درخواست دهنده")]
        public long appuser_id { get; set; }

        [Display(Name = "علت تخلف")]
        public int  reason_id { get; set; }


        [Display(Name = " توضیحات تخلف")]
        public string message { get; set; }


        public bool isenable { get; set; }



        [ForeignKey("product_id")]
        public virtual Product Tbl_product { get; set; }

       

        [ForeignKey("appuser_id")]
        public virtual UserApp Tbl_UserApp { get; set; }


        [ForeignKey("reason_id")]
        public virtual ReportReason Tbl_ReportReason { get; set; }

    }
}
