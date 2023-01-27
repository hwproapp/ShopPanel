using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class AdvertisePlanState
    {
        [Key]
        public int Id { get; set; }

        public long adv_id { get; set; }

        public int plan_id { get; set; }

        public DateTime startdateml { get; set; }
        public string startdatesh { get; set; }

        public DateTime expiredateml { get; set; }
        public string expiredatesh { get; set; }


        //nav


        [ForeignKey(nameof(plan_id))]
        public virtual  Plan Tbl_Plan { get; set; }

        
        [ForeignKey(nameof(adv_id))]
        public virtual shopadvertise Tbl_Shopadv { get; set; }

    }
}
