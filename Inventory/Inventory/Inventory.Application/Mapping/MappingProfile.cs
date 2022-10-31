using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Inventory.Application.Commands;
using Inventory.Application.Models;
using Inventory.System.Domain.Products;

namespace Inventory.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            _ = this.CreateMap<Product, CreateProductCommand>();
            _ = this.CreateMap<Product, ProductQuery>();
            _ = this.CreateMap<ProductQuery, Product>();
        }
    }
}
