using DatabaseAccess.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DatabaseAccess.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IApiDbContext>(provider => provider.GetService<ApiDbContext>());
            return services;
        }
    }
}
