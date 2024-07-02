using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using MultiShop.Discount.Context;
using MultiShop.Discount.Services;
using System.Reflection;

namespace MultiShop.Discount.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDiscountService, DiscountService>();
        }

        public static void ConfigureDatabase(this IServiceCollection services)
        {
            services.AddTransient<DapperContext>();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
            {
                opts.Audience = "ResourceDiscount";
                opts.Authority = configuration["IdentityServerUrl"];
                opts.RequireHttpsMetadata = false;
            });
        }
    }
}
