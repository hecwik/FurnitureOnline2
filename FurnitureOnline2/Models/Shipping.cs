using System;
using System.Collections.Generic;

#nullable disable

namespace FurnitureOnline2.Models
{
    public partial class Shipping
    {
        public Shipping()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Specification { get; set; }

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
