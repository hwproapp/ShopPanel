using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ContactUs : BaseClass
    {

        [Key]
        public int Id { get; set; }


        [Display(Name ="کاربر")]
        public long appuser_id { get; set; }


        [Display(Name = "عنوان")]
        public string title { get; set; }


        [Display(Name = "توضیحات")]
        public string body { get; set; }

        public bool isenable { get; set; }



        [ForeignKey("appuser_id")]

        public virtual UserApp Tbl_UserApp { get; set; }

    }
}
