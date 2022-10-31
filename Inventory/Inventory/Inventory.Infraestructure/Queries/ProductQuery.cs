using Inventory.Application.Interfaces;
using Inventory.System.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infraestructure.Queries
{
    public class ProductQuery : IProductQueryRepository
    {
        private readonly InventoryContext context;
        public ProductQuery(InventoryContext context) {
            this.context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return this.context.Products.ToList();
        }

        public Product GetById(Guid id)
        {
            return this.context.Products.Where(o => o.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return this.context.Products.Where(o => o.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}
