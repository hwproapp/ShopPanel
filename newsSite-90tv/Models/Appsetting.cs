using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Appsetting
    {

        [Key]
        public int Id { get; set; }

        // admin bank account


        [Display(Name = "مالک حساب")]
        public string ownername { get; set; }


        [Display(Name = " شماره شبا بانکی")]
        public string shabacode { get; set; }

        //.......  

        [Display(Name = "درباره ما")]
        public string  about { get; set; }


        [Display(Name = "ایمیل (تماس با ما)")]
        public string email { get; set; }


        [Display(Name = " شماره تماس (تماس با ما)")]
        public string phone { get; set; }


        [Display(Name = "کارمزد فروش")]
        public int wage { get; set; }


       // public bool isEnable { get; set; }



        public string user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual ApplicationUsers user { get; set; }

    }
}
