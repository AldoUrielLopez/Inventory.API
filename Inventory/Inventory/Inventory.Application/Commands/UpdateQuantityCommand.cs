using AutoMapper;
using Inventory.Application.Interfaces;
using Inventory.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Inventory.Application.Commands
{
    public class UpdateQuantityCommand : IRequest<ProductQuery>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateQuantityCommand, ProductQuery> 
    {
        private readonly IMapper mapper;
        private readonly IProductRepository repository;
        private readonly IProductQueryRepository query;

        public UpdateProductCommandHandler(IProductRepository repository, IProductQueryRepository query,
            IMapper mapper)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.query = query ?? throw new ArgumentNullException(nameof(query));
        }

        public Task<ProductQuery> Handle(UpdateQuantityCommand request, CancellationToken cancellationToken)
        {
            try {
                var productExists = this.query.GetById(request.Id);
                if (productExists == null)
                {
                    string message = $"El producto {request.Id} no existe";
                    throw new Exception(message);
                }

                this.repository.Update(request.Id, request.Quantity);
                var productUpdated = this.query.GetById(request.Id);

                return Task.FromResult<ProductQuery>(this.mapper.Map<ProductQuery>(productUpdated));

            } catch (Exception) 
            { 
                throw; 
            }
        }

    }


}
