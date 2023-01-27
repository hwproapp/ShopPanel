using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ProdProp
    {
        [Key]
        public int Id { get; set; }
        public long product_id { get; set; }

        public int property_id { get; set; }

        // property value
        public string value { get; set; }

        [ForeignKey("property_id")]
        public virtual Property Tbl_Property { get; set; }

        [ForeignKey("product_id")]
        public virtual Product Tbl_Product { get; set; }
    }
}
