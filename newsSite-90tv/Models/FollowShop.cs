using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class FollowShop 
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="کاربر دنبال کننده")]
        public string usertoken { get; set; }


        [Display(Name = "کاربر دنبال کننده")]
        public long userapp_id { get; set; }



        [Display(Name = "فروشگاه دنبال شده")]
        public long shop_id { get; set; }


     
        public  bool  isenable { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        public DateTime dateMiladi { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public string dateShamsi { get; set; }


        [Display(Name ="زمان ایجاد")]
        public string time { get; set; }

        //nav 
        [ForeignKey("shop_id")]
        public virtual Shop shop { get; set; }

        [ForeignKey("userapp_id")]
        public virtual UserApp TblUserApp { get; set; }

    }
}
