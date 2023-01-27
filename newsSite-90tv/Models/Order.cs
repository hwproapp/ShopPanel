using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }


        [Display(Name ="خریدار")]
        public long appuser_id { get; set; }


        [Display(Name = "جمع کل سفارش")]
        public int sumprice { get; set; }


        [Display(Name = "هزینه پستی ")]
        public int postprice { get; set; }


        [Display(Name = "نوع پست ")]
        public byte posttype { get; set; }


        [Display(Name = "ادرس خریدار ")]
        public int useradd_id { get; set; } // user address select


        [Display(Name = "کد سفارش ")]
        public string codeorder { get; set; } // is unique


        [Display(Name = "وضیعت پرداخت  ")]
        public bool isfinish { get; set; }

        public DateTime datemiladi { get; set; }


        [Display(Name = "تاریخ ایجاد  ")]
        public string dateshamsi { get; set; }


        public DateTime finishdatemiladi { get; set; }


        [Display(Name = "تاریخ تکمیل   ")]
        public string finishdateshamsi { get; set; }



        public bool isEnable { get; set; }



        [ForeignKey("appuser_id")]
        public virtual UserApp Tbl_UserApp { get; set; }


        






    }
}
