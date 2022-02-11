using System;
using System.Collections.Generic;

#nullable disable

namespace FurnitureOnline2.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public bool? HiddenSupplier { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
