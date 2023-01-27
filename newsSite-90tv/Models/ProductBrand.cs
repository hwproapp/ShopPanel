using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ProductBrand
    {

        [Key]
        public int Id { get; set; }

        [Display(Name ="نام برند")]
        public string name { get; set; }

        [Display(Name = "نام برند (انگلیسی)")]
        public string nameen { get; set; }

        public bool isenable { get; set; }


    }
}
