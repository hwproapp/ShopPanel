using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class sellerBank :BaseClass
    {
        [Key]
        public long Id { get; set; }
        

        [Display(Name ="فروشنده")]
        public long seller_id { get; set; }
        

        [Display(Name = "شماره کارت بانکی")]
        public string BankNom { get; set; }

        [Display(Name = "شماره شبا بانکی")]
        public string shabNom { get; set; }

    
        [Display(Name ="مالک حساب")]
        public string owner { get; set; }

        

        [Display(Name = "نام بانک")]
        public string bankname { get; set; }

   
        public bool isenable { get; set; }

        public string user_id { get; set; }
        



        [ForeignKey("seller_id")]
        public virtual Salsman Tbl_Salsman { get; set; }


        [ForeignKey("user_id")]
        public virtual ApplicationUsers Tbl_User { get; set; }
    }
}
