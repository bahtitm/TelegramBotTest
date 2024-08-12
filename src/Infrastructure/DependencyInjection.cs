using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>((sp, options) =>
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IDbContextFactory<AppDbContext>, ContextFactory<AppDbContext>>();
            services.AddTransient<IApplicationDbContext>(provider => provider.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext());

            
            return services;
        }
    }
}
