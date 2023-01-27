using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class SizeCategory
    {
        [Key]
        public int Id { get; set; }

        public int cat_id { get; set; }

        public int size_id { get; set; }

        [ForeignKey("cat_id")]
        public virtual Category Tbl_Category { get; set; }

        [ForeignKey("size_id")]
        public virtual Size Tbl_Size { get; set; }
    }
}
