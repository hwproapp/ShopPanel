using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class bannerImage
    {
        public long Id { get; set; }

        public  long  banner_id { get; set; }


        public string image { get; set; }



        [ForeignKey("banner_id")]
        public virtual workerBanner Tbl_WorkerBanner { get; set; }
    }
}
