using Inventory.System.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Inventory.Application.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Añade un producto al repositorio
        /// </summary>
        /// <param name="product"></param>
        void Add(Product product);
        /// <summary>
        /// Actualiza un producto del repositorio
        /// </summary>
        /// <param name="product"></param>
        void Update(Guid id, int quantity);
    }
}
