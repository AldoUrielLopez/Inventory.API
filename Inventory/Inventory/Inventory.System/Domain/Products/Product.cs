using Inventory.System.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.System.Domain.Products
{
    public class Product : Entity, IAggregateRoot
    {
        public string? Name { get; set; }
        public string? BarCode { get; set; }
        public int Quantity { get; set; }
        public decimal PriceUnit { get; set; }

        private Product() { }

        public Product(string? name, string? barCode, int quantity, decimal priceUnit)
        {
            this.Name = name;
            this.BarCode = barCode;
            this.Quantity = quantity;
            this.PriceUnit = priceUnit;
            this.Id = Guid.NewGuid();
        }
    }
}
