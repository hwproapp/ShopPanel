using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "نام خصوصیت")]
        public string name { get; set; }


        [Display(Name = " بخش")]
        public int part_id { get; set; }


        [Display(Name = " دسته بندی")]
        public int cat_id { get; set; }

        public bool isenable { get; set; }



        [ForeignKey("part_id")]
        public virtual Part Tbl_Part { get; set; }


        [ForeignKey("cat_id")]
        public virtual Category Tbl_Category { get; set; }
    }
}
