using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SysPizzaria.Domain.Contracts.Interfaces.Repositories;
using SysPizzaria.Infra.Data.Context;
using SysPizzaria.Infra.Data.Repositories;

namespace SysPizzaria.Infra.IoC
{
    public static class DependencyInjectionInfra
    {
        public static void ConfigureDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                var serverVersion = ServerVersion.AutoDetect(connectionString);
                options.UseMySql(connectionString, serverVersion);
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IPurchasesRepository, PurchasesRepository>();
        }
        public static void UseMigration(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<BaseDbContext>();
            db.Database.Migrate();
        }
    }
}