using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Sellfix
    {


        [Key]
        public int Id { get; set; }


        [Display(Name ="فروش مربوط")]
        public int sell_id { get; set; }


        public DateTime createdateml { get; set; }

        [Display(Name = "تاریخ واریز")]
        public string  createdatesh { get; set; }


        [ForeignKey(nameof(sell_id))]
        public virtual Sell Tbl_Sell { get; set; }


    }
}
