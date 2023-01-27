using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ReportReason
    {
        [Key]
        public int Id { get; set; }


        [Display(Name ="عنوان دلیل")]
        public string title { get; set; }


        public bool isenable { get; set; }
    }
}
