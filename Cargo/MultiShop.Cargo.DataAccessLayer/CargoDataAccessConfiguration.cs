using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.EntityFramework;

namespace MultiShop.Cargo.DataAccessLayer
{
    public static class CargoDataAccessConfiguration
    {
        public static void ConfigureDal(this IServiceCollection services)
        {
            services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
            services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
            services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
            services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
        }
    }
}
