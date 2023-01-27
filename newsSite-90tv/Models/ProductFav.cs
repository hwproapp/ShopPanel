using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class ProductFav
    {
        public int Id { get; set; }

        public long appuser_id { get; set; }

        public long product_id { get; set; }
    }
}
