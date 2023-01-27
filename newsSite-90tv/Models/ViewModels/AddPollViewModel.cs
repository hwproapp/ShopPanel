using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class AddPollViewModel
    {
        [Display(Name = "سوال نظرسنجی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicClass.PublicConst.EnterMessage)]
        public string Question { get; set; }

        [Display(Name = "پاسخ ها")]
        [Required(AllowEmptyStrings = false, ErrorMessage = PublicClass.PublicConst.EnterMessage)]
        public string Answer { get; set; }

    }

    public class VoteResultViewModel
    {
        public int data { get; set; }
        public string label { get; set; }
    }
}
