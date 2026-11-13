using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smartclean.core.Interfaces;
using Smartclean.infrastructure.Data;
using Smartclean.infrastructure.Repositries;

namespace Smartclean.infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            var connectionString = configuration.GetConnectionString("Smartclean")
                ?? throw new InvalidOperationException("Connection string 'Smartclean' was not found.");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
