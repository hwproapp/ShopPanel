using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="نام بخش")]
        public string key { get; set; }

        public bool isenable { get; set; }
    }
}
