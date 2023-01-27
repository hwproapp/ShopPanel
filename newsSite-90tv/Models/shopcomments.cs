using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class shopcomments : BaseClass
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "کاربر")]
        public long appuser_id { get; set; }

        [Display(Name = "در پاسخ")]
        public int replyto { get; set; }

        [Display(Name = "درباره فروشگاه")]
        public long shop_id { get; set; }

        [Display(Name = "پیام")]
        public string body { get; set; }


        public bool IsEnable { get; set; }


        [ForeignKey("shop_id")]
        public virtual Shop Tbl_Shop { get; set; }



        [ForeignKey("appuser_id")]
        public virtual UserApp Tbl_UserApp { get; set; }
    }
}
