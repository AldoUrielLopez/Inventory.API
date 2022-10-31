using AutoMapper;
using Inventory.Application.Interfaces;
using Inventory.Application.Models;
using Inventory.System.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Inventory.Application.Commands
{
    public class CreateProductCommand : IRequest<ProductQuery>
    {
        public string? Name { get; set; }
        public string? BarCode { get; set; }
        public int Quantity { get; set; }
        public decimal PriceUnit { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductQuery>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository repository;
        private readonly IProductQueryRepository query;

        public CreateProductCommandHandler(IProductRepository repository, IProductQueryRepository query, IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.query = query ?? throw new ArgumentNullException(nameof(query));
        }

        public Task<ProductQuery> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productExists = this.query.GetByName(request.Name);
                if (productExists != null && productExists.Any())
                {
                    string message = $"El producto {request.Name} ya existe";
                    throw new Exception(message);
                }

                // Se trasforma el comando en el objeto del repositorio y lo doy de alta.
                var newProduct = new Product(request.Name, request.BarCode, request.Quantity, request.PriceUnit);

                // Se agrega objeto al repositorio.
                this.repository.Add(newProduct);

                // Return object
                return Task.FromResult<ProductQuery>(this.mapper.Map<ProductQuery>(newProduct));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
