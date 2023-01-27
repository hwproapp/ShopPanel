using newsSite90tv.PublicClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ProductGallary 
    {


        [Key]
        public long Id { get; set; }

        public long product_id { get; set; }


        public string imagepath { get; set; }



        
        [ForeignKey("product_id")]
        public virtual Product product { get; set; }

        

    }

   
}
