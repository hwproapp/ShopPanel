using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class BaseClass
    {

        [Display(Name = "زمان ایجاد")]
        public DateTime dateMiladi { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public string dateShamsi { get; set; }
        [Display(Name = "وضیعت")]
        public byte status { get; set; }

        public BaseClass()
        {
            dateMiladi = DateTime.Now;
            dateShamsi = DateAndTimeShamsi.DateTimeShamsi();
        }
    }
}
