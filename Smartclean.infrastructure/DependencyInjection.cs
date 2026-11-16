using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Smartclean.core.Interfaces;
using Smartclean.core.Services;
using Smartclean.infrastructure.Data;
using Smartclean.infrastructure.Repositories;
using Smartclean.infrastructure.Services;

namespace Smartclean.infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepositry<>), typeof(GenricRepositry<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IImageManagementService, ImageManagementService>();
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));

            var connectionString = configuration.GetConnectionString("Smartclean")
                ?? throw new InvalidOperationException("Connection string 'Smartclean' was not found.");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}
