using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class payment
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "پرداخت کننده")]
        public long appuser_id { get; set; }
        

        [Display(Name ="مبلغ پرداختی")]
        public long amount { get; set; }


        public long order_id { get; set; }


        [Display(Name ="تاریخ پرداخت")]
        public string dateshamsi { get; set; }

        public DateTime datemiladi { get; set; }

    

        [Display(Name ="وضیعت پرداخت")]
        public bool isSuccess { get; set; }

        

        [Display(Name ="توضیحات")]
        public string comment { get; set; }

        
        [Display(Name = "شماره رهگیری پرداخت")]
        public string refid { get; set; }
        
      
        public bool isenable { get; set; }

       
        [ForeignKey("appuser_id")]
        public virtual UserApp Tbl_UserApp { get; set; }
        

    }
}
