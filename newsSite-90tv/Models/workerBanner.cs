using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class workerBanner : BaseClass
    {
        [Key]
        public long Id { get; set; }


        [Display(Name ="عنوان آگهی")]
        public string title { get; set; }


        [Display(Name = "تصویر شاخص آگهی")]
        public string image { get; set; }


        [Display(Name = "شرح  کامل آگهی")]
        public string desc { get; set; }



        [Display(Name = "دسته بندی")]
        public int category_id { get; set; }



        [Display(Name = "درخواست دهنده")]
        public long appuser_id { get; set; }



        [Display(Name = "شهر")]
        public int city_id { get; set; }



        [Display(Name = "استان")]
        public int ostan_id { get; set; }



        [Display(Name = "تعداد بازدید")]
        public int viewcount { get; set; }



        public bool isenable { get; set; }




        public DateTime todate { get; set; }





        //nav

        [ForeignKey("appuser_id")]
        public virtual UserApp Tbl_UserApp { get; set; }


        [ForeignKey("category_id")]
        public virtual Category Tbl_Category { get; set; }


        [ForeignKey("city_id")]
        public virtual City Tbl_City { get; set; }


        [ForeignKey("ostan_id")]
        public virtual Ostan Tbl_Ostan { get; set; }




    }
}
