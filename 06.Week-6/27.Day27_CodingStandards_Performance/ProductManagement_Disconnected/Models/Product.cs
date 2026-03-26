using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement_Disconnected.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
