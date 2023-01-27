using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Size
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = " نام سایز")]
        public string name { get; set; } // 32   // large

        //[Display(Name = "دسته بندی")]
        //public int cat_id { get; set; } // shoe   //closet

        public bool isEnable { get; set; }


        [ForeignKey("cat_id")]
        public virtual Category Tbl_Category { get; set; }





    }
}
