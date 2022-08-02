using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DbContextProfi.Extensions
{
    public static class RegisterDbExtensions
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DbContextProfiСonnector>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
