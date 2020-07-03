using System;
using System.Collections.Generic;

namespace WebAppi.Models
{
    public partial class Users
    {
        public Users()
        {
            Address = new HashSet<Address>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int AddresId { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
