using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Product : BaseClass
    {
        [Key]
        public long Id { get; set; }

        [Display(Name ="عنوان ")]
        public string title { get; set; }


        [Display(Name = "توضیح مختصر")]
        public string summary { get; set; }


        [Display(Name = " توضیحات کامل")]
        public string desc { get; set; }


        [Display(Name ="قیمت (تومان)")]
        public long price { get; set; }


        [Display(Name = "درصد تخفیف")]
        public int offpercent { get; set; }


        [Display(Name = "فروشنده")]
        public long shop_id { get; set; }


        public  long seller_id { get; set; }


        [Display(Name = "دسته بندی")]
        public int cat_id { get; set; }


        [Display(Name = "برند محصول")]
        public int brand_id { get; set; }

        
        [Display(Name ="تصویر  محصول")]
        public string image { get; set; }
        

        [Display(Name = "تعداد لایک")]
        public int likeCount { get; set; }


        [Display(Name = "تعداد بازدید")]
        public int viewCount { get; set; }


        [Display(Name = "وزن محصول (گرم)")]
        public int weight { get; set; }

        
        [Display(Name = "تعداد")]
        public int qty { get; set; }

        
        [Display(Name = "کد محصول")]
        public string code { get; set; }


        [Display(Name = "کلمات کلیدی")]
        public string keyword { get; set; }


        [Display(Name = "گارانتی")]
        public string garanty { get; set; }
    

        [Display(Name = "وضیعت موجود بودن")]
        public bool isexist { get; set; }

        public bool enable { get; set; }


        [Display(Name = "وضیعت انتشار")]
        public bool ispublish { get; set; }


        public string User_id { get; set; }

        





        //nav
        [ForeignKey("brand_id")]
        public virtual ProductBrand brand { get; set; }

        [ForeignKey("User_id")]
        public virtual ApplicationUsers user { get; set; }


        [ForeignKey("cat_id")]
        public virtual Category Tbl_Category { get; set; }


        [ForeignKey("shop_id")]
        public virtual Shop Tbl_Shop { get; set; }



        [ForeignKey("seller_id")]
        public virtual Salsman Tbl_Salsman { get; set; }





    }

  
}
