using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Color 
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="نام رنگ")]
        public string name { get; set; }

        [Display(Name = "  نام رنگ انگلیسی")]

        public string nameen { get; set; }


        [Display(Name = "کد رنگ")]

        public string code { get; set; }


        public bool isenable { get; set; }
    }
}
