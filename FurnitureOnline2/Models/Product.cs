using System;
using System.Collections.Generic;

#nullable disable

namespace FurnitureOnline2.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? CurrentPrice { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public bool? ChosenItem { get; set; }
        public int? StockUnit { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public int ArticleNumber { get; set; }
        public double? Moms { get; set; }
        public bool? HiddenArticle { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
