using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Buycheck : BaseClass
    {

        [Key]
        public int Id { get; set; }

        [Display(Name ="خرید")]
        public int buy_id { get; set; }


        [Display(Name ="توضیحات")]
        public string desc { get; set; }

        public bool isenable { get; set; }



        [ForeignKey(nameof(buy_id))]
        public virtual Buy Tbl_Buy { get; set; }
    }
}
