using System;
using System.Collections.Generic;

namespace WebAppi.Models
{
    public partial class Items
    {
        public Items()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Prize { get; set; }

        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
