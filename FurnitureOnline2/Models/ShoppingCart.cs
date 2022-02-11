using System;
using System.Collections.Generic;

#nullable disable

namespace FurnitureOnline2.Models
{
    public partial class ShoppingCart
    {
        public int Id { get; set; }
        public int? AmountOfItems { get; set; }
        public int? ProductsId { get; set; }

        public virtual Product IdNavigation { get; set; }
    }
}
