using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Plan 
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام پلن (فارسی)")]
        public string namefa { get; set; }

        [Display(Name = "نام پلن (انگلیسی)")]
        public string nameen { get; set; }

        [Display(Name = "نوع پلن")]
        public byte plantype { get; set; } // year or mnth or ...

        [Display(Name = "مدت")]
        public byte count { get; set; }

        [Display(Name = "توضیحات پلن")]
        public string desc { get; set; }

        [Display(Name = "قیمت(ریال)")]
        public int price { get; set; }

        [Display(Name = "تخفیف% ")]
        public int offpercent { get; set; }


        [Display(Name = "استفاده پلن برای")]
        public byte type { get; set; } // shop plan or banner plan

        public bool isEnable { get; set; }

        [Display(Name = "زمان ایجاد")]
        public DateTime dateMiladi { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public string dateShamsi { get; set; }


    }
}
