using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class UserApp 
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "نام")]
        public string firstName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string lastName { get; set; }

        [Display(Name = " شماره تماس ثابت")]
        public string phone { get; set; }

        [Display(Name = "شماره همراه")]
        public string mobile { get; set; }
        

        [Display(Name = "تصویر کاربر")]
        public string image { get; set; }


      


        [Display(Name = "جنسیت")]
        public byte gender { get; set; }


        [Display(Name = "ایمیل")]
        public string email { get; set; }
        

        public string mobileActiveCode { get; set; }


        [Display(Name = "وضیعت فعال سازی شماره همراه")]
        public bool mobileActiveStatus { get; set; }
        

        [Display(Name = "کد ملی")]
        public string nationalcode { get; set; }



        [Display(Name = "تاریخ تولد")]
        public string birthdate { get; set; }


        public bool isEnable { get; set; }

        [Display(Name = "ماهیت کاربر")]
        public byte type { get; set; }

        public DateTime datemiladi { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        public string dateshamsi { get; set; }

        public string token { get; set; }



      

        //nav
        public string User_id { get; set; }

        [ForeignKey("User_id")]
        public virtual ApplicationUsers user { get; set; }



    }
}
