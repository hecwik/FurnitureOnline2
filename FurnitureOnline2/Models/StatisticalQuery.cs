using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureOnline2.Models
{
    class StatisticalQuery
    {
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public int? TotalProductPrice { get; set; }
        public string City { get; set; }
    }
}
