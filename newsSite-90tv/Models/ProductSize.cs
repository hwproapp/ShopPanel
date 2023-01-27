using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ProductSize
    {

        [Key]
        public int Id { get; set; }
        public long product_id { get; set; }
        public int size_id { get; set; }



        [ForeignKey("product_id")]
        public virtual Product Tbl_Product { get; set; }


        [ForeignKey("size_id")]
        public virtual Size Tbl_Size { get; set; }
    }
}
