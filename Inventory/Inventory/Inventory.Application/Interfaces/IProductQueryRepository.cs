using Inventory.System.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces
{
    public interface IProductQueryRepository
    {
        Product GetById(Guid id);

        IEnumerable<Product> GetByName(string name);

        IEnumerable<Product> GetAll();
    }
}
