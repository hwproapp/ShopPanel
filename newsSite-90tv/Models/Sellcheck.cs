using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Sellcheck : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int sell_id { get; set; }

        public string desc { get; set; }

        public bool isenable { get; set; }


        [ForeignKey(nameof(sell_id))]
        public virtual Sell Tbl_Sell { get; set; }
    }
}
