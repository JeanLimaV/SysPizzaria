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
        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
            services
                .AddDbContext<BaseDbContext>(dbContextOptions =>
                    {
                        dbContextOptions
                            .UseMySql(connectionString, serverVersion)
                            .LogTo(Console.WriteLine, LogLevel.Information)
                            .EnableSensitiveDataLogging()
                            .EnableDetailedErrors();
                    }
                );

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