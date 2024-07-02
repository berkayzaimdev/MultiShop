using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Infrastructure
{
    public static class OrdersInfrastructureConfiguration
    {
        public static void AddOrdersInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<OrderContext>();        
        }
    }
}
