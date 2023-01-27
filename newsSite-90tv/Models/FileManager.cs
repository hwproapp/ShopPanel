using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class FileManager
    {
        [Key]
        public long Id { get; set; }

        public string path { get; set; }

        //public string filetype { get; set; }

        //public bool status { get; set; }

        //public DateTime createdate { get; set; }

    }
}
