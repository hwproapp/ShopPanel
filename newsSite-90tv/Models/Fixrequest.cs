using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Fixrequest : BaseClass
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "فروشنده درخواست دهنده")]
        public long seller_id { get; set; }
       
        public bool isenable { get; set; }

        [ForeignKey(nameof(seller_id))]
        public virtual Salsman Tbl_Salsman{ get; set; }


    }
}
