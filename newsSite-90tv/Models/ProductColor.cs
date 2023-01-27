using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ProductColor 
    {

        [Key]
        public long Id { get; set; }
        
        public long product_id { get; set; }

        public int color_id { get; set; }

     

        [ForeignKey("color_id")]
        public virtual Color Tbl_color { get; set; }

        [ForeignKey("product_id")]
        public virtual Product Tbl_Product { get; set; }

    
        
    }
}
