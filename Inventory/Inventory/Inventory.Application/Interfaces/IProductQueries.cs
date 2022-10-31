using Inventory.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces
{
    public interface IProductQueries
    {
        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductQuery> GetAll();

        /// <summary>
        /// Obtiene productos por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ProductQuery GetById(Guid Id);

        /// <summary>
        /// Obtiene productos segun el nombre dado
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<ProductQuery> GetByName(string name);
    }
}
