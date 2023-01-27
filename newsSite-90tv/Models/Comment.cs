using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Comment : BaseClass
    {
        [Key]
        public int Id { get; set; }



        [Display(Name = "عنوان نظر")]
        public string title { get; set; }


        [Display(Name = "بدنه نظر")]
        public string body { get; set; }


        [Display(Name = "کاربر")]
        public long appuser_id { get; set; }

 

        [Display(Name = "درباره محصول")]
        public long product_id { get; set; }

       

        public bool isEnable { get; set; }


        [ForeignKey("product_id")]
        public virtual Product Tbl_Products { get; set; }
        

        [ForeignKey("appuser_id")]
        public virtual UserApp Tbl_UserApp { get; set; }

    }
}
