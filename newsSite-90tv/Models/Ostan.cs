using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Ostan 
    {

        [Key]
        public int Id { get; set; }
        public string title { get; set; }

        
    }
}
