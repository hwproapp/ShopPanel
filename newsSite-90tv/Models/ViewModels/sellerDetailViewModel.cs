using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.ViewModels
{
    public class sellerDetailViewModel
    {
        public Salsman seller { get; set; }
        public IEnumerable<sellerBank> bankinfo { get; set; }
    }
}
