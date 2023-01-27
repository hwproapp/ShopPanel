using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class UserAlarm : BaseClass
    {

        [Key]
        public long Id { get; set; }

        public long appuser_id { get; set; }

        public string title { get; set; }

        public string body { get; set; }

        public bool isenable { get; set; }


        [ForeignKey(nameof(appuser_id))]
        public virtual UserApp Tbl_Userapp { get; set; }


    }
}
