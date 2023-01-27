using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Shop : BaseClass
    {
        [Key]
        public long Id { get; set; }

        [Display(Name ="نام فروشگاه")]
        public string title { get; set; }

        [Display(Name = "شرح فعالیت فروشگاه")]
        public string summary { get; set; }

        [Display(Name ="دسته بندی")]
        public int cat_id { get; set; }

        [Display(Name = "تصویر فروشگاه")]
        public string image { get; set; }


        [Display(Name = "فروشنده فروشگاه")]
        public long seller_id { get; set; }

        
        [Display(Name = " استان")]
        public int ostan_id { get; set; }

        [Display(Name = " شهر")]
        public int city_id { get; set; }
        

        [Display(Name = "آدرس فروشگاه")]
        public string address { get; set; }
        

        [Display(Name = "عرض جغرافیایی")]
        public string lat { get; set; }


        [Display(Name = "طول جغرافیایی")]
        public string lot { get; set; }


        [Display(Name ="تعداد بازدید")]
        public int viewCount { get; set; }

        public string user_id { get; set; }
        public bool enable { get; set; }


        [ForeignKey("ostan_id")]
        public virtual Ostan Tblostan { get; set; }

        [ForeignKey("city_id")]
        public virtual City Tblcity { get; set; }

        [ForeignKey("user_id")]
        public virtual ApplicationUsers user { get; set; }

        [ForeignKey("seller_id")]
        public virtual Salsman salsman { get; set; }


        [ForeignKey("cat_id")]
        public virtual Category Tbl_Category { get; set; }




    }
}
