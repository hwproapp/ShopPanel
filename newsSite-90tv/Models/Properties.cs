using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Properties
    {
        [Key]

        public int Id { get; set; }

        [Display(Name ="نام خصوصیت ")]
        public string name { get; set; }

        [Display(Name ="دسته بندی")]
        public int category_id { get; set; }

        public bool isEnable { get; set; }

        // nav

        [ForeignKey(nameof(category_id))]
        public virtual Category Tbl_Category { get; set; }
    }


    public class PropertiesValue
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = " خصوصیت")]
        public int properties_id { get; set; }


        [Display(Name ="مقدار خصوصیت")]
        public string value { get; set; }



        public bool isEnable { get; set; }

        // nav

        [ForeignKey(nameof(properties_id))]
        public virtual Properties Tbl_Properties { get; set; }

    }


    public class ProductProperties
    {

        [Key]
        public int id { get; set; }


        [Display(Name = "محصول")]
        public long product_id { get; set; }


        [Display(Name = "خصوصیت")]
        public int properties_id { get; set; }


        [Display(Name = "مقدار خصوصیت")]
        public int propertiesvalue_id { get; set; }


        // nav

        [ForeignKey(nameof(propertiesvalue_id))]
        public virtual PropertiesValue Tbl_PropertiesValue { get; set; }


        [ForeignKey(nameof(product_id))]
        public virtual Product Tbl_Product { get; set; }


        [ForeignKey(nameof(properties_id))]
        public virtual Properties Tbl_Properties { get; set; }
    }
}
