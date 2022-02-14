using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureOnline2
{
    class ShowSpecificOrderQuery
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public float? TotalAmount { get; set; }
        public string ShippingAdress { get; set; }
        public string ShippingZipCode { get; set; }
        public string ShippingCity { get; set; }
        public int? ArticleNr { get; set; }
        public string ArticleName { get; set; }
        public int? Quantity { get; set; }
        public float? ProductPrice { get; set; }
        public string ShippingMethod { get; set; }
        public int Payment { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }

    }
}
