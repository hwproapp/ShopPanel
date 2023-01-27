using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class shopadvertise : BaseClass
    {
        [Key]
        public long Id { get; set; }
        
        [Display(Name = "تصویر تبلیغاتی")]
        public string image { get; set; }

        public long appuser_id { get; set; }

        [Display(Name = "فروشگاه مربوط")]
        public long shop_id { get; set; }
       
        public DateTime fromdatemiladi { get; set; }
        public DateTime todatemiladi { get; set; }


        [Display(Name = "شروع نمایش تبلیغ")]
        public string fromdateshamsi { get; set; }

        [Display(Name = "پایان نمایش تبلیغ")]
        public string todateshamsi { get; set; }
        public bool isenable { get; set; }
        public string users_id { get; set; }
     

        [ForeignKey("shop_id")]
        public virtual Shop Shop { get; set; }

        [ForeignKey("users_id")]
        public virtual ApplicationUsers User  { get; set; }

    }
}
