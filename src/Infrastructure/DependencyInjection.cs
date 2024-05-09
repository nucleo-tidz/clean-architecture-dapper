using Applictaion.Common.Interface;
using Infrastructure.Common;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ConnectionFactory>();
            return services.AddRepository();
        }
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>()
                .AddTransient<IInventoryRepository, InventoryRepository>()
                .AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
