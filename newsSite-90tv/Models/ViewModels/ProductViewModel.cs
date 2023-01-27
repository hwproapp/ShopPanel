using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class ProductViewModel
    {

        [Display(Name = "نام/عنوان")]
        public string title { get; set; }


        [Display(Name = " توضیحات مختصر")]
        public string summary { get; set; }


        [Display(Name = " توضیحات کامل")]
        public string desc { get; set; }


        [Display(Name = "دسته بندی")]
        public int cat_id { get; set; }

        [Display(Name = "برند ")]

        public int brand_id { get; set; }

        
        [Display(Name = "وزن محصول (گرم)")]
        public int weight { get; set; }

        [Display(Name = "تصویر شاخص محصول")]
        public string image { get; set; }

        [Display(Name = "وضیعت چند فروشندگی")]
        public bool ismultisell { get; set; }



        #region MyRegion
        //[Display(Name = "فروشگاه")]
        //public long shop_id { get; set; }


        //[Display(Name = "قیمت")]
        //public long price { get; set; }


        //[Display(Name = "تخفیف%")]
        //public byte offpercent { get; set; }

        //[Display(Name = "تعداد محصول")]
        //public byte qty { get; set; }
        #endregion

    }
}
