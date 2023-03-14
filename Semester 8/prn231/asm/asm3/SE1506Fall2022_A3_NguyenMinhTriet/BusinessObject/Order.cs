using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }

        public virtual eStoreUser Member { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public class ReportPayload
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
