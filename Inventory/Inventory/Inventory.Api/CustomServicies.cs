using System;
using Inventory.Application.Mapping;
using MediatR;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Api
{
    public static class CustomServicies
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddMediatR(typeof(Application.Commands.CreateProductCommand).GetTypeInfo());
            services.AddMediatR(typeof(Application.Commands.UpdateProductCommandHandler).GetTypeInfo());

            services.AddTransient<Application.Interfaces.IProductQueries, Application.Queries.ProductQueries>();
            services.AddTransient<Application.Interfaces.IProductQueryRepository, Infraestructure.Queries.ProductQuery>();
            services.AddScoped<Application.Interfaces.IProductRepository, Infraestructure.Repositories.ProductRepositories>();

            // Add auto mapper
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }

    }
}
