using System;
using System.Collections.Generic;

#nullable disable

namespace FurnitureOnline2.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductsId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }

        public virtual OrderHistory Order { get; set; }
    }
}
