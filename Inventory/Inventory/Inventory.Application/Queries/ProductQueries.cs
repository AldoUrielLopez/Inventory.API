using AutoMapper;
using Inventory.Application.Interfaces;
using Inventory.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly IMapper mapper;
        private readonly IProductQueryRepository query;

        public ProductQueries(IProductQueryRepository query, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.query = query ?? throw new ArgumentNullException(nameof(query));
        }

        public IEnumerable<ProductQuery> GetAll() {
            return this.mapper.Map<IEnumerable<ProductQuery>>(this.query.GetAll());
        }

        public ProductQuery GetById(Guid id)
        {
            return this.mapper.Map<ProductQuery>(this.query.GetById(id));
        }

        public IEnumerable<ProductQuery> GetByName(string name)
        {
            return this.mapper.Map<IEnumerable<ProductQuery>>(this.query.GetByName(name));
        }
    }
}
