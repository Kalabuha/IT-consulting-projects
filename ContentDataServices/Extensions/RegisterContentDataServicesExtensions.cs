using Microsoft.Extensions.DependencyInjection;
using ServiceInterfaces;

namespace ContentDataServices.Extensions
{
    public static class RegisterContentDataServicesExtensions
    {
        public static IServiceCollection RegisterContentDataServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationService, ApplicationDataService>();
            services.AddScoped<IProjectService, ProjectDataService>();
            services.AddScoped<IServiceService, ServiceDataService>();
            services.AddScoped<IBlogService, BlogDataService>();

            return services;
        }
    }
}
