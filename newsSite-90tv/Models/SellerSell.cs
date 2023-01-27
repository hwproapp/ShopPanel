using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models
{
    public class SellerSell
    {
        [Key]
        public long Id { get; set; }

        public long appuser_id { get; set; }


        public long orderdetail_id { get; set; }


        public byte sellstate { get; set; }

        public bool isenable { get; set; }

        public byte fixstate { get; set; }


        public DateTime createdateml { get; set; }


        public string createdatesh { get; set; }


        [ForeignKey("orderdetail_id")]
        public virtual orderDetail Tbl_OrderDetail { get; set; }

        [ForeignKey("appuser_id")]
        public virtual UserApp Tbl_UserApp { get; set; }

    }
}
