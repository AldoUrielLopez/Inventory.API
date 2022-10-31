using Inventory.Application.Interfaces;
using Inventory.System.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infraestructure.Repositories
{
    public class ProductRepositories : IProductRepository
    {
        private readonly InventoryContext context;

        public ProductRepositories(InventoryContext context)
        {
            this.context = context;
        }

        public void Add(Product product) 
        { 
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public void Update(Guid id, int quantity) 
        { 
            var product = this.context.Products.Where(o => o.Id == id).FirstOrDefault();
            product.Quantity = product.Quantity + (quantity);
            this.context.SaveChanges();
        }
    }
}
