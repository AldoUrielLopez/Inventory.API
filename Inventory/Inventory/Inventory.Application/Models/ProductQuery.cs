using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Models
{
    public class ProductQuery
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? BarCode { get; set; }
        public int Quantity { get; set; }
        public decimal PriceUnit { get; set; }
    }
}
