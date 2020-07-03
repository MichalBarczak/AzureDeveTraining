using System;
using System.Collections.Generic;

namespace WebAppi.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItem = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public int AddressId { get; set; }
        public decimal TotalPrize { get; set; }

        public virtual Address Address { get; set; }
        public virtual OrderStatus Status { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
