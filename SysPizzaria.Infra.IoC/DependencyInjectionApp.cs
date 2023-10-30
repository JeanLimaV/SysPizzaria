using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SysPizzaria.Application.Interfaces;
using SysPizzaria.Application.Mappings;
using SysPizzaria.Application.Notifications;
using SysPizzaria.Application.Services;
using SysPizzaria.Application.Services.Interfaces;

namespace SysPizzaria.Infra.IoC
{
    public static class DependencyInjectionApp
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDbContext(configuration);
            
            services.AddRepositories();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<INotificator, Notificator>();
        }

        public static void CreateAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile<AutoMapperProfile>());
        }
    }
}