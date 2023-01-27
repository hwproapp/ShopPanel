using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class City
    {

        [Key]
        public int Id { get; set; }
        public string title { get; set; }

        public int ostan_id { get; set; }


        [ForeignKey("ostan_id")]
        public virtual Ostan Tblostan { get; set; }




    }
}
