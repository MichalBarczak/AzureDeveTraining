using System;
using System.Collections.Generic;

namespace WebAppi.Models
{
    public partial class Address
    {
        public Address()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public bool IsMainAddress { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
