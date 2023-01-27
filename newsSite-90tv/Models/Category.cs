using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="عنوان دسته بندی")]
        public string Title { get; set; }

        [Display(Name = "والد دسته بندی")]
        public int ParentId { get; set; }

        [Display(Name = "تصویر")]
        public string image { get; set; }


        [Display(Name = "نوع دسته بندی")]
        public byte type { get; set; }


        public bool isenable { get; set; }


        [Display(Name = "زمان ایجاد")]
        public string dateshamsi { get; set; }

        [Display(Name = "زمان ایجاد")]
        public DateTime datemiladi { get; set; }

        
    }
}
