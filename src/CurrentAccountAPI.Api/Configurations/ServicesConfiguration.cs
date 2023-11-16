using CurrentAccountAPI.Domain.Interface;
using CurrentAccountAPI.Domain.Interface.Repository;
using CurrentAccountAPI.Domain.Interface.Service;
using CurrentAccountAPI.Domain.Notificacoes;
using CurrentAccountAPI.Domain.Services;
using CurrentAccountAPI.Infra.Database;
using CurrentAccountAPI.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CurrentAccountAPI.Api.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddCustomServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextClass>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<DbContextClass>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionService, TransactionService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
