using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;

namespace MultiShop.Cargo.BusinessLayer
{
    public static class CargoBusinessConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
            services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
            services.AddScoped<ICargoDetailService, CargoDetailManager>();
            services.AddScoped<ICargoOperationService, CargoOperationManager>();
        }
    }
}
