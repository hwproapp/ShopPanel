using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class Poll
    {
        public int PollId { get; set; }
        public string Question { get; set; }
        public string PollStartDate { get; set; }
        public string PollEndDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PollOption> pollOption { get; set; }
    }


    public class PollOption
    {
        public int PolloptionID { get; set; }
        public int PollID { get; set; }
        public string Answer { get; set; }
        public int VouteCount { get; set; }

        public virtual Poll poll { get; set; }
    }
}
