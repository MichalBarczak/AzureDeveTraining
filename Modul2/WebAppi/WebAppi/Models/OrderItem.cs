using System;
using System.Collections.Generic;

namespace WebAppi.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int NumberOfItems { get; set; }
        public decimal Prize { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }

        public virtual Items Item { get; set; }
        public virtual Orders Order { get; set; }
    }
}
